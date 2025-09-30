using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2sem3lab
{
    public class OrderEventArgs(Order order, string message = "") : EventArgs
    {
        public Order Order { get; set; } = order;
        public string Message { get; set; } = message;
    }
}