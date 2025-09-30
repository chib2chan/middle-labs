using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2sem4lab;

namespace _2sem4lab
{
    /// <summary>
    /// класс "Повар"
    /// </summary>
    public class Chef
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CuisineType TypeOfCuisine { get; set; }
        public int OrdersHandled { get; set; }
    }
}
