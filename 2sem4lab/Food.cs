using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2sem3lab;

namespace _2sem3lab
{
    public class Food(string name, double price)
    {
        public string Name { get; set; } = name;
        public double Price { get; set; } = price;
    }
}