using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzCo
{
    class Order
    {
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public List<string> Pizzas { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }


        private List<Order> LoadOrders()
        {
            throw new ArgumentException("Invalid filePath");
        }

        public void GetOrderHistory(string id)
        {
            throw new ArgumentException("Invalid id", nameof(id));
        }

       
    }
}
