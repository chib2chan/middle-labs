using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2sem3lab;

namespace _2sem3lab
{
    public class Client(string name, double balance)
    {
        public string Name { get; set; } = name;
        public double Balance { get; set; } = balance;
        public List<Order> Orders { get; private set; } = [];

        /// <summary>
        /// метод для фиксирования оплаты заказа
        /// </summary>
        /// <param name="sender">кто вызвал событие (Кофейня)</param>
        /// <param name="e">содержимое заказа</param>
        /// <returns></returns>
        public string PayCheck(CoffeeHouse sender, OrderEventArgs e)
        {
            ArgumentNullException.ThrowIfNull(sender);
            ArgumentNullException.ThrowIfNull(e);
            if (Balance >= e.Order.TotalPrice)
            {
                Balance -= e.Order.TotalPrice;
                Orders.Add(e.Order);
                return $"Payment successful! Remaining balance: {Balance}R";
            }
            return "You don't have enough money on your card. Please, pay by cash.";
        }
    }
}