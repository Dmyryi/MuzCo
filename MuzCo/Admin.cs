using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzCo
{
    class Admin:User
    {
        private List<Pizza> allPizzas;
        private string ordersFile = "orders.json"; 
        private string pizzasFile = "data.json";

    

        public override void ShowMenu(User registeredUser)
        {
            throw new ArgumentException("Invalid registeredUser", nameof(registeredUser));
        }

        private void DeleteOrder()
        { throw new ArgumentException("Invalid"); }

        private void AddNewPizza()
        { throw new ArgumentException("Invalid "); }

        private List<Pizza> LoadPizzasFromJson()
        { throw new ArgumentException("Invalid "); }

        private void SavePizzasToJson()
        { throw new ArgumentException("Invalid "); }

        private void LoadOrdersFromJson()
        { throw new ArgumentException("Invalid "); }

        private void SaveOrdersToJson()
        { throw new ArgumentException("Invalid "); }
        }
}
