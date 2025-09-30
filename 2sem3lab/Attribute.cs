using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2sem2lab
{
    /// <summary>
    /// Класс скрытых атрибутов, наследуется от встроенного класса атрибутов
    /// </summary>
    public class HiddenAttribute : Attribute
    {
        public HiddenAttribute() { }
    }    
}