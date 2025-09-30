using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2sem3lab;

namespace _2sem3lab
{
    public class Order
    {
        public List<Food> Items { get; set; } = [];
        public double TotalPrice { get; private set; }
        public bool DeliveryRequired { get; set; }

        /// <summary>
        /// метод, подсчитывающий общую стоимость заказа
        /// </summary>
        public void CalculateOrder()
        {
            TotalPrice = Items.Sum(item => item.Price);
        }

        /// <summary>
        /// метод, возвращающий чек за заказ
        /// </summary>
        /// <returns>чек в виде строки</returns>
        public override string ToString()
        {
            return "\n\t-----------" +
                   $"\n\tOrdered:\n\t * {string.Join("\n\t * ", Items.Select(item => $"{item.Name} ({item.Price})"))}" +
                   $"\n\tTo be paid: {TotalPrice}R" +
                   $"\n\tNeed delivery: {(DeliveryRequired ? "yes" : "no")}" +
                   "\n\t-----------" + 
                   "\n\nThank you for your visit!";
        }
    }
}