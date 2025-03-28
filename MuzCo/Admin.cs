using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzCo
{
    public class Admin:User
    {
        private List<Pizza> allPizzas;
        private string ordersFile = "orders.json"; 
        private string pizzasFile = "data.json";

        public Admin(string id, string userName, string password) : base(id, userName, password, UserRole.Customer)
        {

            throw new NotImplementedException();
        }

        public override void ShowMenu(User registeredUser)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder()
        { throw new NotImplementedException(); }

        public void AddNewPizza()
        { throw new NotImplementedException(); }

        private List<Pizza> LoadPizzasFromJson()
        { throw new NotImplementedException(); }

        private void SavePizzasToJson()
        { throw new NotImplementedException(); }

        private void LoadOrdersFromJson()
        { throw new NotImplementedException(); }

        private void SaveOrdersToJson()
        { throw new NotImplementedException(); }
        }
}
