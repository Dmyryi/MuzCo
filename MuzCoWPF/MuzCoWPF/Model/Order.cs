using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzCoWPF.Model
{
    class Order
    {
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public List<string> Pizzas { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }

        public string Status { get; set; }
    }
}
