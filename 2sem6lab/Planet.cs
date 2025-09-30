using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finally5lab2sem
{
    public class Planet
    {
        public double m;

        public double x;
        public double y;

        public double Vx;
        public double Vy;

        public double fx;
        public double fy;

        public List<Point> Trail;

        public Planet(double m, double Vx, double Vy, double x, double y)
        {
            this.m = m;
            this.Vx = Vx;
            this.Vy = Vy;
            this.x = x;
            this.y = y;
            Trail = new List<Point>();
        }
    }
}
