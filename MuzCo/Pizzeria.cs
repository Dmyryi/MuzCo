using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzCo
{
   public class Pizzeria:ICreateOrder
    {
        private List<Pizza> pizzas = new List<Pizza>();
        
        public void LoadData(string filePath)
        {
            throw new ArgumentException("Invalid file path", nameof(filePath));
        }

        public void CreateOrder(string userId)
        {
            throw new ArgumentException("Invalid userId", nameof(userId));
        }

       private void SaveOrder(Order order)
        {
            throw new ArgumentException("Invalid order", nameof(order));
        }
    }
}
