using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzCo
{
    class Customer:User
    {
        private Pizzeria pizzeria;
        private Order order;

        public override void ShowMenu(User registeredUser)
        {
            throw new ArgumentException("Invalid registeredUser", nameof(registeredUser));
        }
    }
}