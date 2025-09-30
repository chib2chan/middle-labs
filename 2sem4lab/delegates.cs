using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2sem3lab;

namespace _2sem3lab
{
    public delegate void CheckHandler(Client client, CoffeeHouse sender, OrderEventArgs e);

    public delegate void DeliveryHandler(Courier courier);

    public delegate List<Food> OrderedFood(List<Food> menu);

    public delegate string CreateOrder(Client client, List<Food> food, bool delivery, CheckHandler paymentHandler);
}
