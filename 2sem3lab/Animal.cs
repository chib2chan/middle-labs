using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2sem2lab
{
    /// <summary>
    /// Класс для объектов типа "Зверек": имеет имя, возраст и вес + скрытый атрибут "риск" (безумно можно быть первым)
    /// </summary>
    public class Animal
    {
        public string Species { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }

        /// <summary>
        /// сокрытие при помощи атрибута
        /// </summary>
        [Hidden]
        public double Risk { get; set; }
    }
}
