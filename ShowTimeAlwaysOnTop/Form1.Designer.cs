namespace ShowTimeAlwaysOnTop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PB = new System.Windows.Forms.PictureBox();
            this.BtnShow = new System.Windows.Forms.Button();
            this.BtnHide = new System.Windows.Forms.Button();
            this.TBOpacity = new System.Windows.Forms.TrackBar();
            this.LblOpacity = new System.Windows.Forms.Label();
            this.TBSize = new System.Windows.Forms.TrackBar();
            this.LblSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBSize)).BeginInit();
            this.SuspendLayout();
            // 
            // PB
            // 
            this.PB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB.BackColor = System.Drawing.Color.Black;
            this.PB.Location = new System.Drawing.Point(15, 187);
            this.PB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PB.Name = "PB";
            this.PB.Size = new System.Drawing.Size(797, 443);
            this.PB.TabIndex = 0;
            this.PB.TabStop = false;
            this.PB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PB_MouseDown);
            this.PB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PB_MouseMove);
            // 
            // BtnShow
            // 
            this.BtnShow.Location = new System.Drawing.Point(310, 14);
            this.BtnShow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(88, 27);
            this.BtnShow.TabIndex = 1;
            this.BtnShow.Text = "Show";
            this.BtnShow.UseVisualStyleBackColor = true;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // BtnHide
            // 
            this.BtnHide.Location = new System.Drawing.Point(428, 14);
            this.BtnHide.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnHide.Name = "BtnHide";
            this.BtnHide.Size = new System.Drawing.Size(88, 27);
            this.BtnHide.TabIndex = 2;
            this.BtnHide.Text = "Hide";
            this.BtnHide.UseVisualStyleBackColor = true;
            this.BtnHide.Click += new System.EventHandler(this.BtnHide_Click);
            // 
            // TBOpacity
            // 
            this.TBOpacity.Location = new System.Drawing.Point(130, 47);
            this.TBOpacity.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TBOpacity.Maximum = 100;
            this.TBOpacity.Name = "TBOpacity";
            this.TBOpacity.Size = new System.Drawing.Size(682, 45);
            this.TBOpacity.TabIndex = 3;
            this.TBOpacity.Value = 100;
            this.TBOpacity.Scroll += new System.EventHandler(this.TBOpacity_Scroll);
            // 
            // LblOpacity
            // 
            this.LblOpacity.AutoSize = true;
            this.LblOpacity.Location = new System.Drawing.Point(19, 53);
            this.LblOpacity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblOpacity.Name = "LblOpacity";
            this.LblOpacity.Size = new System.Drawing.Size(76, 15);
            this.LblOpacity.TabIndex = 5;
            this.LblOpacity.Text = "Transparency";
            // 
            // TBSize
            // 
            this.TBSize.Location = new System.Drawing.Point(130, 106);
            this.TBSize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TBSize.Maximum = 100;
            this.TBSize.Minimum = 10;
            this.TBSize.Name = "TBSize";
            this.TBSize.Size = new System.Drawing.Size(682, 45);
            this.TBSize.TabIndex = 4;
            this.TBSize.Value = 10;
            this.TBSize.Scroll += new System.EventHandler(this.TBSize_Scroll);
            // 
            // LblSize
            // 
            this.LblSize.AutoSize = true;
            this.LblSize.Location = new System.Drawing.Point(36, 112);
            this.LblSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblSize.Name = "LblSize";
            this.LblSize.Size = new System.Drawing.Size(27, 15);
            this.LblSize.TabIndex = 6;
            this.LblSize.Text = "Size";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 647);
            this.Controls.Add(this.LblSize);
            this.Controls.Add(this.LblOpacity);
            this.Controls.Add(this.TBSize);
            this.Controls.Add(this.TBOpacity);
            this.Controls.Add(this.BtnHide);
            this.Controls.Add(this.BtnShow);
            this.Controls.Add(this.PB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Time Always On Top";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox PB;
        private Button BtnShow;
        private Button BtnHide;
        private TrackBar TBOpacity;
        private TrackBar TBSize;
        private Label LblOpacity;
        private Label LblSize;
    }
}