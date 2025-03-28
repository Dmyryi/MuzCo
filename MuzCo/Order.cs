using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzCo
{
    public class Order
    {
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public List<string> Pizzas { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }

        public Order()
        {
            throw new NotImplementedException();
        }

        public Order(string userId, List<string> pizzas, double totalPrice)
        {
            throw new NotImplementedException();
        }

        private List<Order> LoadOrders()
        {
            throw new NotImplementedException();
        }

        public void GetOrderHistory(string id)
        {
            throw new NotImplementedException();
        }

       
    }
}
