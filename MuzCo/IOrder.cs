using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzCo
{
    public interface IOrder
    {

        public List<Order> GetOrderHistory(string id);
    }
}
