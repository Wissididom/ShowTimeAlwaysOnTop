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
            Time = $"{DateTime.Now.Hour:D2}:{DateTime.Now.Minute:D2}";
            Invalidate();
        }

        private void TimeView_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString(Time, Font, new SolidBrush(Color.FromArgb(255, Color)), 10F, 10F);
        }
    }
}
