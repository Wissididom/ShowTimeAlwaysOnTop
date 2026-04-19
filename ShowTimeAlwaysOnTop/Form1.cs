using System.Text;
using System.Text.Json;

namespace ShowTimeAlwaysOnTop
{
    public partial class Form1 : Form
    {
        private readonly TimeView Tv = new();
        private int X, Y;
        private bool TimeShown = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var configPath = Path.Combine(Application.StartupPath, "config.json");
            if (!File.Exists(configPath))
                return;
            var config = JsonSerializer.Deserialize<Config>(File.ReadAllText(configPath));
            if (config is not null)
            {
                if (config.Time is not null)
                {
                    if (config.Time.X > 0)
                        Tv.Location = new Point(config.Time.X, Tv.Location.Y);
                    if (config.Time.Y > 0)
                        Tv.Location = new Point(Tv.Location.X, config.Time.Y);
                    if (config.Time.Font is not null)
                        Tv.Font = new Font(new FontFamily(config.Time.Font), Tv.Font.Size, FontStyle.Regular);
                    if (config.Time.Color is not null)
                    {
                        if (config.Time.Color.A > 0)
                            Tv.Color = Color.FromArgb(config.Time.Color.A, Tv.Color.R, Tv.Color.G, Tv.Color.B);
                        if (config.Time.Color.R > 0)
                            Tv.Color = Color.FromArgb(Tv.Color.A, config.Time.Color.R, Tv.Color.G, Tv.Color.B);
                        if (config.Time.Color.G > 0)
                            Tv.Color = Color.FromArgb(Tv.Color.A, Tv.Color.R, config.Time.Color.G, Tv.Color.B);
                        if (config.Time.Color.B > 0)
                            Tv.Color = Color.FromArgb(Tv.Color.A, Tv.Color.R, Tv.Color.G, config.Time.Color.B);
                    }
                }
                if (config.TimeShown)
                {
                    Tv.Show();
                    TimeShown = true;
                }
                else
                {
                    Tv.Hide();
                    TimeShown = false;
                }
                if (config.Transparency > 0)
                {
                    TBOpacity.Value = config.Transparency;
                    Tv.Opacity = config.Transparency / 100D;
                }
                if (config.Size > 0)
                {
                    TBSize.Value = config.Size;
                    Tv.Font = new(Tv.Font.FontFamily, config.Size, FontStyle.Regular);
                }
                if (config.X > 0)
                    Location = new Point(config.X, Location.Y);
                if (config.Y > 0)
                    Location = new Point(Location.X, config.Y);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var configPath = Path.Combine(Application.StartupPath, "config.json");
            var config = new Config
            {
                Time = new Config.ConfigTime
                {
                    X = Tv.Location.X,
                    Y = Tv.Location.Y,
                    Font = Tv.Font.FontFamily.Name,
                    Color = new Config.ConfigColor
                    {
                        A = Tv.Color.A,
                        R = Tv.Color.R,
                        G = Tv.Color.G,
                        B = Tv.Color.B
                    }
                },
                TimeShown = TimeShown,
                Transparency = TBOpacity.Value,
                Size = TBSize.Value,
                X = Location.X,
                Y = Location.Y
            };
            File.WriteAllText(configPath, JsonSerializer.Serialize(config));
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            Tv.Show();
            TimeShown = true;
        }

        private void BtnHide_Click(object sender, EventArgs e)
        {
            Tv.Hide();
            TimeShown = false;
        }

        private void BtnChangeColor_Click(object sender, EventArgs e)
        {
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                Tv.Color = colorPicker.Color;
            }
        }

        private void PB_MouseDown(object sender, MouseEventArgs e)
        {
            X = Control.MousePosition.X - Tv.Location.X;
            Y = Control.MousePosition.Y - Tv.Location.Y;
        }

        private void TBOpacity_Scroll(object sender, EventArgs e)
        {
            Tv.Opacity = TBOpacity.Value / 100D;
        }

        private void TBSize_Scroll(object sender, EventArgs e)
        {
            Tv.Font = new(Tv.Font.FontFamily, TBSize.Value, FontStyle.Regular);
        }

        private void PB_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var newPoint = Control.MousePosition;
                newPoint.X -= X;
                newPoint.Y -= Y;
                Tv.Location = newPoint;
                Application.DoEvents();
            }
        }
    }
}
