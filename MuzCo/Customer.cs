using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzCo
{
    public class Customer:User
    {
        private Pizzeria pizzeria;
        private Order order;

        public Customer(string id, string userName, string password) : base(id, userName, password, UserRole.Customer)
        {

            throw new NotImplementedException();

        }

        public override void ShowMenu(User registeredUser)
        {
            throw new NotImplementedException();
        }
    }
}