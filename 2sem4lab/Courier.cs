using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2sem3lab;

namespace _2sem3lab
{
    public class Courier
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public bool IsAvailable { get; set; }

        public event DeliveryHandler DeliveryNotify;

        /// <summary>
        /// метод, который показывает, какой курьер готов принять заказ
        /// </summary>
        public void ReadyToDeliveryHandler()
        {
            IsAvailable = true;
            Console.WriteLine($"Courier {Name} is going to deliver the order.\n(His rating is {Rating * 100}%)");
            DeliveryNotify?.Invoke(this);
        }

        /// <summary>
        /// метод, выводящий курьера, доставившего заказ
        /// </summary>
        /// <param name="courier">выполнивший свое задание курьер</param>
        public void CourierDeliveryNotify(Courier courier)
        {
            Thread.Sleep(5000);
            Console.WriteLine($"\nCourier {Name} delivered your order!");
        }
    }
}