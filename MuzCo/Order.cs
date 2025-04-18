using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MuzCo
{
    public class Order
    {
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public List<string> Pizzas { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }

        public string Status { get; set; }

   
        private string ordersFile = "orders.json";
       
        public static event Action<string> OnOrderPlaced;

        public Order()
        {
    
        }

        public Order(string userId, List<string> pizzas, double totalPrice, string status)
        {
            //if (string.IsNullOrWhiteSpace(userId))
            //    throw new ArgumentException("UserId cannot be empty.", nameof(userId));

            //if (pizzas == null || pizzas.Count == 0)
            //    throw new ArgumentException("Pizzas list cannot be empty.", nameof(pizzas));

            //if (totalPrice <= 0)
            //    throw new ArgumentException("TotalPrice must be greater than zero.", nameof(totalPrice));

            //if (string.IsNullOrWhiteSpace(status))
            //    throw new ArgumentException("Status cannot be empty.", nameof(status));

            OrderId = Guid.NewGuid().ToString();
            UserId = userId;
            Pizzas = pizzas;
            TotalPrice = totalPrice;
            OrderDate = DateTime.Now;
        }


        public void Place()
        {
            // Твоя текущая логика
            OnOrderPlaced?.Invoke("✅ Замовлення оформлено на суму: " + TotalPrice + " ₴");

            SaveToFile("orders.json");
        }

        public void SaveToFile(string filePath)
        {
            List<Order> existing = LoadOrders();
            existing.Add(this);

            string json = JsonConvert.SerializeObject(existing, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }




        public static List<Order> LoadOrders()
        {
            if (!File.Exists("orders.json"))
                return new List<Order>();

            string json = File.ReadAllText("orders.json");
            return JsonConvert.DeserializeObject<List<Order>>(json) ?? new List<Order>();
        }



        public static List<Order> GetOrderHistory(string userId)
        {
            return LoadOrders().Where(o => o.UserId == userId).ToList();
        }


        public override string ToString()
        {
            return
       $"Піци: {string.Join(", ", Pizzas)}\n" +
       $"Загальна ціна: {TotalPrice.ToString("0.00")} ₴\n" +
       
       $"Дата замовлення: {OrderDate}\n";
        }

    }
}
