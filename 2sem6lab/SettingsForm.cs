using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Finally5lab2sem
{
    public partial class SettingsForm : Form
    {
        public int SelectedBodyCount { get; set; }
        public List<Planet> Planets { get; set; } = new List<Planet>();
        public SettingsForm()
        {
            InitializeComponent();
            Planets = new List<Planet>(Form1.planets);
            LoadPlanetsToTextBoxes();
            this.StartPosition = FormStartPosition.CenterParent;
            this.AcceptButton = buttonOK;
            this.CancelButton = buttonCancel;
        }

        /// <summary>
        /// Выполняет разбор данных из текстовых полей, проверяет корректность и обновляет список планет
        /// </summary>
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            try
            {
                var masses = ParseList<double>(textBoxMasses.Text);
                var vx = ParseList<double>(textBoxVx.Text);
                var vy = ParseList<double>(textBoxVy.Text);
                var x = ParseList<double>(textBoxX.Text);
                var y = ParseList<double>(textBoxY.Text);

                if (masses.Count != SelectedBodyCount || vx.Count != SelectedBodyCount ||
                    vy.Count != SelectedBodyCount || x.Count != SelectedBodyCount || y.Count != SelectedBodyCount)
                {
                    MessageBox.Show($"Количество значений в полях должно совпадать с выбранным количеством тел ({SelectedBodyCount}).",
                                  "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Planets.Clear();
                for (int i = 0; i < masses.Count; i++)
                {
                    Planets.Add(new Planet(masses[i], x[i], y[i], vx[i], vy[i]));
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при анализе данных: {ex.Message}", "Ошибка!", MessageBoxButtons.OK);
                DialogResult = DialogResult.Cancel;
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки "отмена"
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Загружает параметры планет в виде списка
        /// </summary>
        private void LoadPlanetsToTextBoxes()
        {
            textBoxMasses.Text = string.Join(", ", Planets.Select(p => p.m.ToString("F10")));
            textBoxVx.Text = string.Join(", ", Planets.Select(p => p.Vx.ToString("F10")));
            textBoxVy.Text = string.Join(", ", Planets.Select(p => p.Vy.ToString("F10")));
            textBoxX.Text = string.Join(", ", Planets.Select(p => p.x.ToString("F10")));
            textBoxY.Text = string.Join(", ", Planets.Select(p => p.y.ToString("F10")));
        }

        /// <summary>
        /// Преобразует строку, содержащую список значений, в удобный список
        /// </summary>
        /// <typeparam name="T">Тип, к которому будут приведены значения</typeparam>
        /// <param name="input">Строка со списком значений</param>
        /// <returns>Список значений нужного типа или пустой список, если строка пуста</returns>
        private List<T> ParseList<T>(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return new List<T>();

            var culture = System.Globalization.CultureInfo.InvariantCulture;
            return input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(item => (T)Convert.ChangeType(item.Trim(), typeof(T), culture))
                       .ToList();
        }

        /// <summary>
        /// небольшая справка о том, что такое масса и на что она влияет
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void LinkLabelMasses_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string title = "Масса";
            string message = "Масса — это фундаментальная величина физики, характеризующая количество вещества в теле. " +
                "Масса влияет на силу притяжения, ускорение при одинаковых силах и другие параметры.";
            ShowInfo(title, message);
        }

        /// <summary>
        /// небольшая справка о том, что такое скорость и на что она влияет
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void LinkLabelVx_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string title = "Скорость по оси X";
            string message = "Скорость по оси X — это проекция скорости на горизонтальную ось. " +
                "Она показывает, как быстро объект движется вправо или влево.";
            ShowInfo(title, message);
        }

        /// <summary>
        ///небольшая справка о том, что такое скорость и на что она влияет
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void LinkLabelVy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string title = "Скорость по оси Y";
            string message = "Скорость по оси Y — это проекция скорости на вертикальную ось. " +
                "Она показывает, как быстро объект движется вверх или вниз.";
            ShowInfo(title, message);
        }

        /// <summary>
        ///небольшая справка о том, что такое координата и на что она влияет
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void LinkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string title = "Координата X";
            string message = "Координата X — это положение объекта по горизонтальной оси. Она используется для описания местоположения объекта в системе координат.";
            ShowInfo(title, message);
        }

        /// <summary>
        ///небольшая справка о том, что такое координата и на что она влияет
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события нажатия</param>
        private void LinkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string title = "Координата Y";
            string message = "Координата Y — это положение объекта по вертикальной оси. Она используется для описания местоположения объекта в системе координат.";
            ShowInfo(title, message);
        }

        /// <summary>
        /// метод, вызывающий всплывающее окно со справкой
        /// </summary>
        /// <param name="title">заголовок всплывающего окна</param>
        /// <param name="message">сообщение, которое видит пользователь</param>
        private void ShowInfo(string title, string message)
        {
            using (Form infoForm = new Form())
            {
                infoForm.Text = title;
                infoForm.StartPosition = FormStartPosition.CenterScreen;

                Label label = new Label
                {
                    Text = message,
                    Dock = DockStyle.Fill,
                    Padding = new Padding(10)
                };

                infoForm.Controls.Add(label);
                infoForm.ShowDialog();
            }
        }
    }
}