using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2sem3lab;

namespace _2sem3lab
{
    public class CoffeeHouse
    {
        public List<Food> Menu { get; set; } = [];
        private List<Courier> AvailableCouriers { get; set; } = [];

        public event DeliveryHandler FindCourierNotify;

        public event CheckHandler CheckNotify;

        /// <summary>
        /// метод для регистрации курьера
        /// </summary>
        /// <param name="courier">курьер, добавляемый в список курьеров</param>
        public void CourierRegister(Courier courier)
        {
            AvailableCouriers.Add(courier);
            courier.DeliveryNotify += (courier) => AvailableCouriers.Add(courier); // Подписка на "незанятость" курьера
        }

        /// <summary>
        /// Метод для формирования заказа
        /// </summary>
        /// <param name="client">для кого заказ</param>
        /// <param name="food">что в заказе</param>
        /// <param name="delivery">требуется ли доставка</param>
        /// <param name="paymentHandler">был ли зафиксирован факт оплаты</param>
        /// <returns></returns>
        public string MakeOrder(Client client, List<Food> food, bool delivery, CheckHandler paymentHandler)
        {
            var order = new Order { Items = food, DeliveryRequired = delivery };
            order.CalculateOrder();
            paymentHandler(client, this, new OrderEventArgs(order));
            client.Orders.Add(order);
            if (delivery)
            {
                List<Courier> availableCouriers = AvailableCouriers.Where(courier => courier.IsAvailable).ToList();
                if (availableCouriers.Count != 0)
                {
                    //ниже переделала Sort на сортировку курьеров по рейтингу
                    availableCouriers.Sort((courier1, courier2) => courier2.Rating.CompareTo(courier1.Rating));
                    var courier = availableCouriers[0];
                    courier.ReadyToDeliveryHandler();
                    courier.CourierDeliveryNotify(courier);
                }
                else
                {
                   return "No available couriers";
                }
            }
            return $"{client.Name}'s order:\n{order.ToString()}";
        }
    }
}