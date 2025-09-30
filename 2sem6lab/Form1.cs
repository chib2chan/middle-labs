using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Finally5lab2sem
{
    public partial class Form1 : Form
    {
        public static List<Planet> planets = new List<Planet>();
        private const double G = 10;
        private const double TimeStep = 0.1;
        public static readonly Timer timer = new Timer { Interval = 16 };

        public Bitmap trajectoryBitmap;

        public Panel PanelForPlanets = new Panel();

        public CheckBox checkBoxTrajectories = new CheckBox();

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            PanelForPlanets.Paint += PanelForPlanets_Paint;
            comboBoxNumberOfPlanet.SelectedIndexChanged += ComboBoxNumberOfPlanet_SelectedIndexChanged;
            checkBoxTrajectories.CheckedChanged += CheckBoxTrajectory_CheckedChanged;
            buttonStart.Click += ButtonStart_Click;
            buttonStop.Click += ButtonStop_Click;
            buttonSettings.Click += ButtonSettings_Click;
            trajectoryBitmap = new Bitmap(PanelForPlanets.Width, PanelForPlanets.Height);
            textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);//для мема
            timer.Tick += Timer1_Tick;
        }

        /// <summary>
        /// таймер, который предназначен для обновления планет
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            CalculateForces();
            UpdatePositions();
            panelForPlanets.Invalidate();
        }

        /// <summary>
        /// Обработчик события запуска
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void ButtonStart_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        /// <summary>
        /// Обработчик события остановки
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void ButtonStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        /// <summary>
        /// Открывает форму с настройками, передает в нее данные о количестве планет, вносит данные о том, какие массы и скорости были присвоены планетам
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            if (comboBoxNumberOfPlanet.SelectedItem != null)
            {
                SettingsForm settingsForm = new SettingsForm
                {
                    SelectedBodyCount = int.Parse(comboBoxNumberOfPlanet.SelectedItem.ToString())
                };
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    planets = settingsForm.Planets;
                    trajectoryBitmap = new Bitmap(panelForPlanets.Width, panelForPlanets.Height);
                    panelForPlanets.Invalidate();
                }
            }
        }

        /// <summary>
        /// Отображает траекторию, вдоль которой двигалась планета в случае активации чек бокса
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void CheckBoxTrajectory_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTrajectory.Checked)
            {
                trajectoryBitmap = new Bitmap(panelForPlanets.Width, panelForPlanets.Height);
                panelForPlanets.Invalidate();
            }
        }

        /// <summary>
        /// выбор числа планет, влияет на количество элементов в форме SettingsForm
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void ComboBoxNumberOfPlanet_SelectedIndexChanged(object sender, EventArgs e) {  }

        private void PanelForPlanets_Paint(object sender, PaintEventArgs e)
        {
            DrawScene(e.Graphics);
        }


        /// <summary>
        /// нахождение расстояние между двумя планетами по формуле
        /// </summary>
        public static double Distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        /// <summary>
        /// расчет взаимодействующих сил для планет по X
        /// </summary>
        private double ForceX(double dx, double distance, double m1, double m2)
        {
            if (distance == 0) return 0;
            return (G * m1 * m2) / (distance * distance) * (dx / distance);
        }

        /// <summary>
        /// расчет взаимодействующих сил для планет по Y
        /// </summary>
        private double ForceY(double dy, double distance, double m1, double m2)
        {
            if (distance == 0) return 0;
            return (G * m1 * m2) / (distance * distance) * (dy / distance);
        }

        /// <summary>
        /// вычисляет гравитационные силы между всеми планетами
        /// </summary>
        private void CalculateForces()
        {
            foreach (var planet in planets)
            {
                planet.fx = 0;
                planet.fy = 0;
            }

            for (int i = 0; i < planets.Count; i++)
            {
                for (int j = i + 1; j < planets.Count; j++)
                {
                    double dx = planets[j].x - planets[i].x;
                    double dy = planets[j].y - planets[i].y;
                    double distance = Distance(planets[i].x, planets[i].y, planets[j].x, planets[j].y);

                    if (distance > 0)
                    {
                        double fx = ForceX(dx, distance, planets[i].m, planets[j].m);
                        double fy = ForceY(dy, distance, planets[i].m, planets[j].m);

                        planets[i].fx += fx;
                        planets[i].fy += fy;
                        planets[j].fx -= fx;
                        planets[j].fy -= fy;
                    }
                }
            }
        }

        /// <summary>
        /// Обновляет положения и скорости планет, учитывая второй закон Ньютона
        /// </summary>
        private void UpdatePositions()
        {
            foreach (var planet in planets)
            {
                planet.Vx += planet.fx / planet.m * TimeStep;
                planet.Vy += planet.fy / planet.m * TimeStep;
                planet.x += planet.Vx * TimeStep;
                planet.y += planet.Vy * TimeStep;

                planet.Trail.Add(new Point((int)planet.x, (int)planet.y));

                if (planet.Trail.Count > 1000) planet.Trail.RemoveAt(0);
            }
        }

        /// <summary>
        /// Отображает текущую сцену с планетами и, при необходимости, их траекториями
        /// </summary>
        private void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);
            if (checkBoxTrajectory.Checked)
            {
                foreach (var planet in planets)
                {
                    if (planet.Trail.Count >= 2)
                    {
                        Color trajectoryColor = GetPlanetColor(planet.m);
                        using (Pen pen = new Pen(trajectoryColor))
                        {
                            g.DrawLines(pen, planet.Trail.ToArray());
                        }
                    }
                }
            }
            foreach (var planet in planets)
            {
                Color color = GetPlanetColor(planet.m);
                double radius = Math.Sqrt(planet.m) * 2;
                float x = (float)planet.x - (float)radius;
                float y = (float)planet.y - (float)radius;
                using (Brush brush = new SolidBrush(color))
                {
                    g.FillEllipse(brush, x, y, (float)(radius * 2), (float)(radius * 2));
                }
            }
        }

        /// <summary>
        /// Возвращает цвет планеты в зависимости от массы (по приколу)
        /// </summary>
        private Color GetPlanetColor(double mass)
        {
            if (mass >= 5)
                return Color.Red;
            else if (mass >= 2 && mass < 5)
                return Color.Yellow;
            else
                return Color.White;
        }


        //не подсматривать!!
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (textBox1.Text == "Tpromo45")
                {
                    Hahatsune form = new Hahatsune();
                    form.Show();
                }
            }
        }
    }
}