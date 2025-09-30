using System;
using System.Text;
using System.Linq;
using _2sem4lab;

namespace _2sem4lab
{
    /// <summary>
    /// класс "Заказ"
    /// </summary>
    public class Order
    {
        public int Id { get; set; } = 0;
        public int TableNumber { get; set; } = 0;
        public int CustomerId { get; set; } = 0;
        public int WaiterId { get; set; } = 0;
        public List<Dish> Dishes { get; set; } = [];
    }
}