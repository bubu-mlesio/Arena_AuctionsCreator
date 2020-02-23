namespace arena.pl
{
    partial class ProgressBar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressinfo_lb = new System.Windows.Forms.Label();
            this.createAuction_pb = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // progressinfo_lb
            // 
            this.progressinfo_lb.AutoSize = true;
            this.progressinfo_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.progressinfo_lb.Location = new System.Drawing.Point(721, 276);
            this.progressinfo_lb.Name = "progressinfo_lb";
            this.progressinfo_lb.Size = new System.Drawing.Size(132, 48);
            this.progressinfo_lb.TabIndex = 1;
            this.progressinfo_lb.Text = "label1";
            // 
            // createAuction_pb
            // 
            this.createAuction_pb.Location = new System.Drawing.Point(75, 80);
            this.createAuction_pb.Name = "createAuction_pb";
            this.createAuction_pb.Size = new System.Drawing.Size(1510, 113);
            this.createAuction_pb.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.createAuction_pb.TabIndex = 0;
            // 
            // ProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2242, 1849);
            this.Controls.Add(this.progressinfo_lb);
            this.Controls.Add(this.createAuction_pb);
            this.Name = "ProgressBar";
            this.Text = "ProgressBar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label progressinfo_lb;
        private System.Windows.Forms.ProgressBar createAuction_pb;
    }
}