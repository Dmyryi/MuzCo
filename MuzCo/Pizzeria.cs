using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MuzCo
{
    public class Pizzeria : ICreateOrder
    {
        public List<Pizza> Pizzas = new List<Pizza>();
  
        private string ordersFile = "orders.json";
        public static event Action<string> UserMenu;

      
        

        public void LoadData(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    UserMenu.Invoke("❌ Файл не знайдено!");
                    return;
                }

                string jsonData = File.ReadAllText(filePath);
                Pizzas = JsonConvert.DeserializeObject<List<Pizza>>(jsonData);
          
            }
            catch (Exception ex)
            {
                UserMenu.Invoke($"❌ Помилка при завантаженні даних: {ex.Message}");
            }
        }



    
        public void CreateOrder(string userId)
        {
            List<string> selectedPizzas = new List<string>();
            double totalPrice = 0;

            while (true)
            {
                UserMenu.Invoke("🍕 Введіть номер піци (або 0 для завершення): ");
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > Pizzas.Count)
                {
                    UserMenu.Invoke("❌ Некоректне введення. Спробуйте ще раз.");
                    continue;
                }

                if (choice == 0) break;

                Pizza selectedPizza = Pizzas[choice - 1];

                UserMenu.Invoke($"🔢 Скільки {selectedPizza.Name} ви хочете замовити? ");
                if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
                {
                    UserMenu.Invoke("❌ Некоректна кількість. Спробуйте ще раз.");
                    continue;
                }

                for (int i = 0; i < quantity; i++)
                {
                    selectedPizzas.Add(selectedPizza.Name);
                }

                totalPrice += selectedPizza.Price * quantity;
                UserMenu.Invoke($"✅ {quantity} шт. {selectedPizza.Name} додано до замовлення.");
            }

            if (selectedPizzas.Count == 0)
            {
                UserMenu.Invoke("❌ Ви не вибрали жодної піци. Замовлення скасовано.");
                return;
            }

          
            Order newOrder = new Order(userId, selectedPizzas, totalPrice, "Очікує підтвердження");
            SaveOrder(newOrder);

            UserMenu.Invoke($"🎉 Замовлення оформлено! Підсумкова сума: {totalPrice}₴");
            UserMenu.Invoke("⏳ Статус замовлення: Очікує підтвердження...");

         
            Task.Run(async () => await UpdateOrderStatus(newOrder));
        }

        private async Task UpdateOrderStatus(Order order)
        {
            await Task.Delay(10000); 
            order.Status = "Збирається";
            UpdateOrderInFile(order);
            UserMenu.Invoke("🔄 Статус замовлення оновлено: Збирається");

            await Task.Delay(20000); 
            order.Status = "Готується";
            UpdateOrderInFile(order);
            UserMenu.Invoke("🔥 Статус замовлення оновлено: Готується");

            await Task.Delay(30000);
            order.Status = "Готово";
            UpdateOrderInFile(order);
            UserMenu.Invoke("✅ Статус замовлення  оновлено: Готово! Можна забирати 🚀");
        }

        private void UpdateOrderInFile(Order updatedOrder)
        {
            if (!File.Exists(ordersFile)) return;

            string json = File.ReadAllText(ordersFile);
            List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(json) ?? new List<Order>();

       
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].UserId == updatedOrder.UserId && orders[i].OrderDate == updatedOrder.OrderDate)
                {
                    orders[i] = updatedOrder;
                    break;
                }
            }

            File.WriteAllText(ordersFile, JsonConvert.SerializeObject(orders, Formatting.Indented));
        }

        private void SaveOrder(Order order)
        {
            List<Order> orders = new List<Order>();

            if (File.Exists(ordersFile))
            {
                string json = File.ReadAllText(ordersFile);
                orders = JsonConvert.DeserializeObject<List<Order>>(json) ?? new List<Order>();
            }

            orders.Add(order);
            File.WriteAllText(ordersFile, JsonConvert.SerializeObject(orders, Formatting.Indented));
        }

      
    }
}
