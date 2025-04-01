using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzCo
{
    public class Pizza
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public bool Favourite { get; set; }

        public Pizza(string name, double price)
        {
            this.Name = name;
            this.Price = price;

            this.Favourite = false;
        }
    }
}
