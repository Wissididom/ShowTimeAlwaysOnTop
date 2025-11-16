using System.ComponentModel;

namespace ShowTimeAlwaysOnTop
{
    public partial class TimeView : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Time
        {
            get;
            set
            {
                field = value;
                Invalidate();
            }
        } = string.Empty;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color Color
        {
            get;
            set
            {
                field = value;
                Invalidate();
            }
        } = Color.Black;

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
            Time = string.Format("{0}:{1}", hour, minute);
            Invalidate();
        }

        private void TimeView_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString(Time, Font, new SolidBrush(Color.FromArgb(255, Color)), 10F, 10F);
        }
    }
}
