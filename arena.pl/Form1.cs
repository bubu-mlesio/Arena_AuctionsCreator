using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace arena.pl
{
    public partial class Menu : Form
    {
        private Dictionary<string, string> shops = new Dictionary<string, string>()
        {
            { "login", @"klucz_api" },
            { "login2", @"klucz_api" }
                };
        private Dictionary<string, int> category = new Dictionary<string, int>()
        {
            {"Elektronika",5941},
            {"Manicure i pedicure",887},
            {"Pozostałe(pielęgnacja i zdrowie)",515},
            {"Szczoteczki",481},
            {"Pasty do zębów",483},
            {"Końcówki do szczoteczek",491},
            {"Szczoteczki elektryczne",6361},
            {"Ciało",819},
            {"Ozdoby",895},
            {"Akryle i żele",897},
            {"Pielęgnacja paznokci",901},
            {"Akcesoria (manicure i pedicure)",891},
            {"Sztuczne paznokcie / Tipsy",10689},
            {"Odżywki i suplementy",1051},
            {"Kompresory",2447},
            {"Pozostałe (narzędzia ogrodnicze)",4149},
            {"Wkrętarki",4329},
            {"Akcesoria kuchenne",4559},
            {"Szatkownice i akcesoria",5729},
            {"Drony i akcesoria",6189},
            {"Pozostałe (elektronika)",7445},
            {"Części i akcesoria do laptopów",5965},
            {"Zasilacze",5975},
            {"Akcesoria (części i akcesoria do laptopów)",5989},
            {"Drony",6193},
            {"Części zamienne",10923},
            {"Pozostałe(AGD)",6233},
            {"Części i akcesoria (do kuchni)",6253},
            {"Sokowirówki",6257},
            {"Wagi kuchenne",6265},
            {"Filtry do wody",6277},
            {"Wyciskarki do owoców",6285},
            {"Pozostałe (do kuchni)",6255},
            {"Odkurzacze i akcesoria",6319},
            {"Pozostałe (do domu)",6305},
            {"Pozostały asortyment (odkurzacze i akcesoria)",6337},
            {"Filtry do odkurzaczy",6339},
            {"Worki do odkurzaczy",6341},
            {"Golarki",6355},
            {"Suszarki do włosów",6369},
            {"Prostownice",6371},
            {"Okapy i akcesoria",6379},
            {"Telewizory i Video",6469},
            {"Kamery",6501},
            {"Zasilanie (kamery)",6509},
            {"Akumulatorki i baterie",6651},
            {"Akcesoria do telefonów",6823},
            {"Smartwatch i akcesoria",7321},
            {"Ładowarki",6865},
            {"Kable",6873},
            {"Powerbanki",6879},
            {"Pozostałe (etui i pokrowce)",6855},
            {"Zasilanie (fotografia)",7361},
            {"Akumulatory (fotografia, zasilanie)",7365},
            {"SD/miniSD/SDHC",7395},
            //{"Akumulatory (usunięty rodzic)",6511},
            //{"Akcesoria (usunięty rodzic)",6521},
            {"Lampy UV",10651},
            {"Lakiery tradycyjne",889},
            {"Lakiery hybrydowe",899}
        };
        private Dictionary<string, string> url = new Dictionary<string, string>(){
            { "sklep", @"link_do_zdjec" },
            { "sklep2", @"link_do_zdjec" }
            };
        private Dictionary<string, string> shopCdnNumber = new Dictionary<string, string>(){
            { "sklep", "dodatek_do_url_zdjec" }
            };
        private Dictionary<string, int> deliveryMethod = new Dictionary<string, int>(){
            { "sklep", 0 }//id_cennika_dostaw
            };
        List<string> titles = new List<string>();
        Thread startOperations = null;
        string user, keyapi, skuExternal, categoryName, description1;
        public int categoryID, quantity1, available;
        float price;

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (startOperations != null)
            {
                if ((startOperations.ThreadState & ThreadState.Running) == ThreadState.Running)
                    startOperations.Abort();
            }
        }

        public Menu()
        {
            InitializeComponent();
            this.Size = new Size(1235, 1165);
            foreach (var shop in shops)
                shop_cb.Items.Add(shop.Key);
            foreach (var cat in category)
                category_cb.Items.Add(cat.Key);
            
        }

        private void addAuctionStart_Click(object sender, EventArgs e)
        {
            if ((String.IsNullOrEmpty(description_tb.Text) || (String.IsNullOrEmpty(price_tb.Text)) || (String.IsNullOrEmpty(title_tb.Text)) || (String.IsNullOrEmpty(stock_tb.Text)) || (String.IsNullOrEmpty(skuExternal_tb.Text))))
            {
                MessageBox.Show("Uzupełnij wszystkie pola", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if((!findCategory(category_cb.Text)) || (!findShop(shop_cb.Text)))
            {
                MessageBox.Show("Uzupełnij wszystkie pola", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string[] titleTMP = title_tb.Text.Split(new string[] { "\n" }, StringSplitOptions.None);
                progressBar1.Visible = true;
                progressBar1.Maximum = titleTMP.Length;
                progress_lb.Visible = true;
                for (int i = 0; i < titleTMP.Length; i++)
                {
                    if(!String.IsNullOrWhiteSpace(titleTMP[i]))
                        titles.Add(titleTMP[i]);
                    progressBar1.Value = i + 1;
                    progress_lb.Text = (i + 1).ToString() + " z " + titleTMP.Length;
                    progress_lb.Refresh();
                    //Thread.Sleep(100);
                }
                progressBar1.Visible = false;
                progressBar1.Value = 0;
                progress_lb.Visible = false;
                progress_lb.Text = "";
                user = shop_cb.Text;
                keyapi = shops[shop_cb.Text];
                categoryID = category[category_cb.Text];
                categoryName = category_cb.Text;
                price = Single.Parse(price_tb.Text) * 100;
                quantity1 = Int32.Parse(stock_tb.Text);
                ThreadStart ts = new ThreadStart(createAuction);
                startOperations = new Thread(ts);
                startOperations.Start();
            }
        }

        private void createAuction()
        {            
            int numberOfTitles = titles.Count();
            progressBar1.Invoke(new Action(delegate ()
            {
                progressBar1.Visible = true;
                progressBar1.Maximum = numberOfTitles;
            }));
            progress_lb.Invoke(new Action(delegate ()
            {
                progress_lb.Visible = true;
            }));
            
            for (int i = 0; i < numberOfTitles; i++)
            {
                skuExternal = skuExternal_tb.Text + @"__" + LongRandom(1000000000, 9999999999, new Random()).ToString();
                description1 = description_tb.Text.Replace("{offer_title}", titles[i]);
                MultiImage miniPhoto = new MultiImage();
                MultiImage photoOne = new MultiImage();
                MultiImage photoTwo = new MultiImage();
                MultiImage photoThree = new MultiImage();
                miniPhoto.url = "http://cdn." + url[user] + "/img/" + skuExternal_tb.Text + "/thumb" + shopCdnNumber[user] + ".png";
                miniPhoto.isThumbnail = true;
                miniPhoto.position = 0;
                photoOne.url = "http://cdn." + url[user] + "/img/" + skuExternal_tb.Text + "/1" + shopCdnNumber[user] + ".jpg";
                photoOne.isThumbnail = false;
                photoOne.position = 1;
                photoTwo.url = "http://cdn." + url[user] + "/img/" + skuExternal_tb.Text + "/2" + shopCdnNumber[user] + ".jpg";
                photoTwo.isThumbnail = false;
                photoTwo.position = 2;
                photoThree.url = "http://cdn." + url[user] + "/img/" + skuExternal_tb.Text + "/3" + shopCdnNumber[user] + ".jpg";
                photoThree.isThumbnail = false;
                photoThree.position = 3;
                CreateProduct product2 = new CreateProduct
                {
                    sellerProductId = skuExternal,
                    name = titles[i].Trim(),
                    availability = 1,
                    description = description1,
                    quantity = quantity1,
                    price = (int)(price * 1.2),
                    pricePromo = (int)price,
                    weight = 1000,
                    deliveryMethodId = deliveryMethod[user],
                    active = true,
                    categoryId = categoryID
            };
                product2.productImages.Add(miniPhoto);
                product2.productImages.Add(photoOne);
                product2.productImages.Add(photoTwo);
                product2.productImages.Add(photoThree);
                
                string json2 = JsonConvert.SerializeObject(product2);
                progressBar1.Invoke(new Action(delegate ()
                {
                    progressBar1.Value = i + 1;
                }));
                progress_lb.Invoke(new Action(delegate ()
                {
                    progress_lb.Text = (i + 1).ToString() + " z " + numberOfTitles;
                    progress_lb.Refresh();
                }));
                string json = sendRequest("api/v4/products", json2, user, keyapi);
                //Dla zwracanych tablic
                /*dynamic blogPosts = JArray.Parse(tmp);
                string tes = "";
                foreach (var t in blogPosts)
                    tes = tes + t.product.created + "\n";*/
                dynamic jsonString = JsonConvert.DeserializeObject(json);
                try
                {
                    string connstring = string.Format(@"Server=server; database=db; UID=login; password=pass");
                    var connection = new MySqlConnection(connstring);
                    connection.Open();
                    string query = "INSERT INTO Auctions " +
                    "(ID_Auction, Titles, SKU, User, id_arena, id) " +
                    "VALUES('" + jsonString.sellerProductId.ToString() + "', '" + titles[i].Trim() + "', '" + skuExternal_tb.Text + "', '" + user + "', '" + jsonString.id.ToString() + "', DEFAULT);";
                    var cmd = new MySqlCommand(query, connection);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                    }
                    connection.Close();
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.ToString(), "Bład", MessageBoxButtons.OK);
                }
            }
            MessageBox.Show("Wszystkie aukcje zostały wystawione", "Auctions", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBar1.Invoke(new Action(delegate ()
            {
                progressBar1.Visible = false;
                progressBar1.Value = 0;
            }));
            progress_lb.Invoke(new Action(delegate ()
            {
                progress_lb.Text = "";
                progress_lb.Visible = false;
            }));
            titles.Clear();
        }

    private string sendRequest(string method, string data, string login, string apikey)
        {
            string url = @"https://arena.pl/" + method;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.ContentType = @"application/json";
            webRequest.Method = "POST";
            String username = login;
            String password = apikey;
            string credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(username + ":" + password));
            webRequest.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);
            
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            webRequest.ContentLength = bytes.Length;
            Stream requestStream = webRequest.GetRequestStream();
            try
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message, "HttpPost: Request error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (requestStream != null)
                    requestStream.Close();
            }
            try
            { // get the response
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                if (webResponse == null)
                { return null; }
                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                return sr.ReadToEnd();
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message, "HttpPost: Response error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        } // end HttpPost 
        private string sendGetRequest(string method, string login, string apikey)
        {
            string url = @"https://arena.pl/" + method;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "GET";
            String username = login;
            String password = apikey;
            string credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(username + ":" + password));
            webRequest.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);
            try
            { 
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                if (webResponse == null)
                { return null; }
                StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                return sr.ReadToEnd();
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message, "HttpPost: Response error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        long LongRandom(long min, long max, Random rand)
        {
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);
            return (Math.Abs(longRand % (max - min)) + min);
        }
        private bool findCategory(string name)
        {
            foreach(var tmp in category)
            {
                if (tmp.Key == name)
                    return true;
            }
            return false;

        }
        private bool findShop(string name)
        {
            foreach(var tmp in shops)
            {
                if (tmp.Key == name)
                    return true;
            }
            return false;
        }
    }
    public class CreateProduct
    {
        public string sellerProductId { get; set; }
        public string name { get; set; }
        public int availability { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int pricePromo { get; set; }
        public int weight { get; set; }
        public List<MultiImage> productImages = new List<MultiImage>();
        public int deliveryMethodId { get; set; }
        public bool active { get; set; }
        public int categoryId { get; set; }
    }
    public class MultiImage
    {
        public string url { get; set; }
        public bool isThumbnail { get; set;}
        public int position {get; set;}
    }
}
