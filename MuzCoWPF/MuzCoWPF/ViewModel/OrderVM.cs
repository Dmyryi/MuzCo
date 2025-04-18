using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzCo;

namespace MuzCoWPF.ViewModel
{
    public class OrderVM
    {
        private readonly Order _order;

        public string Date => _order.OrderDate.ToString("g");
        public string Status => _order.Status;
        public double TotalPrice => _order.TotalPrice;
        public string Pizzas => string.Join(", ", _order.Pizzas);

        public OrderVM(Order order)
        {
            _order = order;
        }
    }
}
