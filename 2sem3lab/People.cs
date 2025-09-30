using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2sem2lab
{
    /// <summary>
    /// Класс для объектов типа "Чел": имеет имя, возраст и проверка наличия работы + скрытый атрибут "риск" (психопаты есть везде)
    /// </summary>
    internal class People
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool HasWork { get; set; }

        /// <summary>
        /// сокрытие при помощи атрибута
        /// </summary>
        [Hidden]
        public double Risk { get; set; }
    }
}
