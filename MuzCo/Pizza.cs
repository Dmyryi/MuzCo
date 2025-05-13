using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzCo
{
    public enum ProductType
    {
        Pizza,
        Drink,
        Sauce,
        None
    }

    public class Pizza
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
  
        public ProductType Type {  get; set; }

        public Pizza(string name, double price, ProductType type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }
    }
}
