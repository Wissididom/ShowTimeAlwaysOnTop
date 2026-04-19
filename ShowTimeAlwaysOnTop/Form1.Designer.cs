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
            PB = new PictureBox();
            BtnShow = new Button();
            BtnHide = new Button();
            TBOpacity = new TrackBar();
            LblOpacity = new Label();
            TBSize = new TrackBar();
            LblSize = new Label();
            BtnChangeColor = new Button();
            colorPicker = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)PB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TBOpacity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TBSize).BeginInit();
            SuspendLayout();
            // 
            // PB
            // 
            PB.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PB.BackColor = Color.Black;
            PB.Location = new Point(15, 187);
            PB.Margin = new Padding(4, 3, 4, 3);
            PB.Name = "PB";
            PB.Size = new Size(797, 443);
            PB.TabIndex = 0;
            PB.TabStop = false;
            PB.MouseDown += PB_MouseDown;
            PB.MouseMove += PB_MouseMove;
            // 
            // BtnShow
            // 
            BtnShow.Location = new Point(273, 14);
            BtnShow.Margin = new Padding(4, 3, 4, 3);
            BtnShow.Name = "BtnShow";
            BtnShow.Size = new Size(88, 27);
            BtnShow.TabIndex = 1;
            BtnShow.Text = "Show";
            BtnShow.UseVisualStyleBackColor = true;
            BtnShow.Click += BtnShow_Click;
            // 
            // BtnHide
            // 
            BtnHide.Location = new Point(369, 14);
            BtnHide.Margin = new Padding(4, 3, 4, 3);
            BtnHide.Name = "BtnHide";
            BtnHide.Size = new Size(88, 27);
            BtnHide.TabIndex = 2;
            BtnHide.Text = "Hide";
            BtnHide.UseVisualStyleBackColor = true;
            BtnHide.Click += BtnHide_Click;
            // 
            // TBOpacity
            // 
            TBOpacity.Location = new Point(130, 47);
            TBOpacity.Margin = new Padding(4, 3, 4, 3);
            TBOpacity.Maximum = 100;
            TBOpacity.Name = "TBOpacity";
            TBOpacity.Size = new Size(682, 45);
            TBOpacity.TabIndex = 3;
            TBOpacity.Value = 100;
            TBOpacity.Scroll += TBOpacity_Scroll;
            // 
            // LblOpacity
            // 
            LblOpacity.AutoSize = true;
            LblOpacity.Location = new Point(19, 53);
            LblOpacity.Margin = new Padding(4, 0, 4, 0);
            LblOpacity.Name = "LblOpacity";
            LblOpacity.Size = new Size(77, 15);
            LblOpacity.TabIndex = 5;
            LblOpacity.Text = "Transparency";
            // 
            // TBSize
            // 
            TBSize.Location = new Point(130, 106);
            TBSize.Margin = new Padding(4, 3, 4, 3);
            TBSize.Maximum = 100;
            TBSize.Minimum = 10;
            TBSize.Name = "TBSize";
            TBSize.Size = new Size(682, 45);
            TBSize.TabIndex = 4;
            TBSize.Value = 10;
            TBSize.Scroll += TBSize_Scroll;
            // 
            // LblSize
            // 
            LblSize.AutoSize = true;
            LblSize.Location = new Point(36, 112);
            LblSize.Margin = new Padding(4, 0, 4, 0);
            LblSize.Name = "LblSize";
            LblSize.Size = new Size(27, 15);
            LblSize.TabIndex = 6;
            LblSize.Text = "Size";
            // 
            // BtnChangeColor
            // 
            BtnChangeColor.Location = new Point(465, 14);
            BtnChangeColor.Margin = new Padding(4, 3, 4, 3);
            BtnChangeColor.Name = "BtnChangeColor";
            BtnChangeColor.Size = new Size(88, 27);
            BtnChangeColor.TabIndex = 7;
            BtnChangeColor.Text = "Change Color";
            BtnChangeColor.UseVisualStyleBackColor = true;
            BtnChangeColor.Click += BtnChangeColor_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(827, 647);
            Controls.Add(BtnChangeColor);
            Controls.Add(LblSize);
            Controls.Add(LblOpacity);
            Controls.Add(TBSize);
            Controls.Add(TBOpacity);
            Controls.Add(BtnHide);
            Controls.Add(BtnShow);
            Controls.Add(PB);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Show Time Always On Top";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)PB).EndInit();
            ((System.ComponentModel.ISupportInitialize)TBOpacity).EndInit();
            ((System.ComponentModel.ISupportInitialize)TBSize).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private PictureBox PB;
        private Button BtnShow;
        private Button BtnHide;
        private TrackBar TBOpacity;
        private TrackBar TBSize;
        private Label LblOpacity;
        private Label LblSize;
        private Button BtnChangeColor;
        private ColorDialog colorPicker;
    }
}