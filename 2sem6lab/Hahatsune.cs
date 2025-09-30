using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finally5lab2sem
{
    public partial class Hahatsune : Form
    {
        public Hahatsune()
        {
            InitializeComponent();

            linkLabel1.LinkClicked += LinkLabel1_LinkClicked;
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://i.pinimg.com/originals/13/a8/25/13a825da2e1e2d1a9c9fe9f67a0be8cb.jpg";
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Че-то не так: {ex.Message}");
            }
        }
    }
}
