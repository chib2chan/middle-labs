using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2sem2lab;

namespace _2sem2lab
{
    /// <summary>
    /// Класс для объектов типа "Дом": имеет адрес, этаж и проверка наличия гаража + скрытый атрибут "риск"
    /// </summary>
    public class House
    {
        public string Address { get; set; }
        public int Floor { get; set; }
        public bool HasGarage { get; set; }

        /// <summary>
        /// сокрытие при помощи атрибута
        /// </summary>
        [Hidden]
        public double Risk { get; set; }
    }
}