namespace ShowTimeAlwaysOnTop
{
    public partial class TimeView : Form
    {
        private string sTime = string.Empty;
        private Color cColor = Color.Black;
        
        public string Time
        {
            get
            {
                return sTime;
            }
            set
            {
                sTime = value;
                Invalidate();
            }
        }

        public Color Color
        {
            get
            {
                return cColor;
            }
            set
            {
                cColor = value;
                Invalidate();
            }
        }

        public TimeView()
        {
            InitializeComponent();
        }

        private void TimeView_Load(object sender, EventArgs e)
        {
            Timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            string hour = DateTime.Now.Hour.ToString();
            string minute = DateTime.Now.Minute.ToString();
            if (DateTime.Now.Hour < 10)
                hour = "0" + hour;
            if (DateTime.Now.Minute < 10)
                minute = "0" + minute;
            sTime = string.Format("{0}:{1}", hour, minute);
            Invalidate();
        }

        private void TimeView_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString(sTime, Font, new SolidBrush(Color.FromArgb(255, Color)), 10F, 10F);
        }
    }
}
