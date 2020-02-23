using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arena.pl
{
    public partial class ProgressBar : Form
    {
        public ProgressBar()
        {
            InitializeComponent();
            createAuction_pb.Maximum = 100;
            createAuction_pb.Step = 1;
        }
        public void loadingBar(int quantity, int now)
        {
            progressinfo_lb.Text = "Pozostało: " + (quantity - now).ToString() + " z " + quantity;
            createAuction_pb.Value = (now/quantity)*100;
            createAuction_pb.Refresh();
            progressinfo_lb.Refresh();
        }
    }
}
