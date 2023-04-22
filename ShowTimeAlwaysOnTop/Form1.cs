using System.Text;

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
            if (!File.Exists(Application.StartupPath + Path.DirectorySeparatorChar + "config.txt"))
                return;
            string[] Lines = File.ReadAllLines(Application.StartupPath + Path.DirectorySeparatorChar + "config.txt");
            foreach (string Line in Lines)
            {
                if (Line.Contains('='))
                {
                    string Key = Line[..Line.IndexOf("=")];
                    string Value = Line[(Line.IndexOf("=") + 1)..];
                    switch (Key)
                    {
                        case "TimeX":
                            Tv.Location = new Point(int.Parse(Value), Tv.Location.Y);
                            break;
                        case "TimeY":
                            Tv.Location = new Point(Tv.Location.X, int.Parse(Value));
                            break;
                        case "TimeFont":
                            Tv.Font = new Font(new FontFamily(Value), Tv.Font.Size, FontStyle.Regular);
                            break;
                        case "TimeColorR":
                            Tv.Color = Color.FromArgb(Tv.Color.A, int.Parse(Value), Tv.Color.G, Tv.Color.B);
                            break;
                        case "TimeColorG":
                            Tv.Color = Color.FromArgb(Tv.Color.A, Tv.Color.R, int.Parse(Value), Tv.Color.B);
                            break;
                        case "TimeColorB":
                            Tv.Color = Color.FromArgb(Tv.Color.A, Tv.Color.R, Tv.Color.G, int.Parse(Value));
                            break;
                        case "TimeShown":
                            if (bool.Parse(Value))
                            {
                                Tv.Show();
                                TimeShown = true;
                            }
                            else
                            {
                                Tv.Hide();
                                TimeShown = false;
                            }
                            break;
                        case "Transparency":
                            TBOpacity.Value = int.Parse(Value);
                            Tv.Opacity = TBOpacity.Value / 100D;
                            break;
                        case "Size":
                            TBSize.Value = int.Parse(Value);
                            Tv.Font = new(Tv.Font.FontFamily, TBSize.Value, FontStyle.Regular);
                            break;
                        case "X":
                            Location = new Point(int.Parse(Value), Location.Y);
                            break;
                        case "Y":
                            Location = new Point(Location.X, int.Parse(Value));
                            break;
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StringBuilder settings = new();
            settings.Append("TimeX=").AppendLine(Tv.Location.X.ToString());
            settings.Append("TimeY=").AppendLine(Tv.Location.Y.ToString());
            settings.Append("TimeFont=").AppendLine(Tv.Font.FontFamily.Name);
            settings.Append("TimeColorR=").AppendLine(Tv.Color.R.ToString());
            settings.Append("TimeColorG=").AppendLine(Tv.Color.G.ToString());
            settings.Append("TimeColorB=").AppendLine(Tv.Color.B.ToString());
            settings.Append("TimeShown=").AppendLine(TimeShown.ToString());
            settings.Append("Transparency=").AppendLine(TBOpacity.Value.ToString());
            settings.Append("Size=").AppendLine(TBSize.Value.ToString());
            settings.Append("X=").AppendLine(Location.X.ToString());
            settings.Append("Y=").AppendLine(Location.Y.ToString());
            File.WriteAllText(Application.StartupPath + Path.DirectorySeparatorChar + "config.txt", settings.ToString());
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
                Point NewPoint = Control.MousePosition;
                NewPoint.X -= X;
                NewPoint.Y -= Y;
                Tv.Location = NewPoint;
                Application.DoEvents();
            }
        }
    }
}