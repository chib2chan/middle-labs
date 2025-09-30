using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2sem2lab;

namespace _2sem2lab
{
    /// <summary>
    /// Класс для объектов типа "Машина": имеет модель, год и цвет + скрытый атрибут "риск"
    /// </summary>
    public class Car
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        /// <summary>
        /// сокрытие при помощи атрибута
        /// </summary>
        [Hidden]
        public double Risk { get; set; }
    }
}