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
            throw new NotImplementedException();
        }

        public void CreateOrder(string userId)
        {
            throw new NotImplementedException();
        }

       private void SaveOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
