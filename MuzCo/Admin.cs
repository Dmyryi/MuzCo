using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MuzCo
{
    public class Admin : User
    {

        private List<Order> allOrders;
        private List<Pizza> allPizzas;
        private string ordersFile = "orders.json";
        private string pizzasFile = "data.json";

        public static event Action<string> OnAdmin;

        public Admin(string id, string userName, string password, UserRole role): base(id, userName, password, role)
        {

            allOrders = new List<Order>();

        }

        public override void ShowMenu(User adminUser)
        {
            while (true)
            {
             
                OnAdmin.Invoke($"Вітаю, {UserName}! (Адміністратор)");
                OnAdmin.Invoke("1. Видалити замовлення користувачів");
                OnAdmin.Invoke("2. Додати нову піцу");
                OnAdmin.Invoke("3. Зберегти JSON з новими піцами");
                OnAdmin.Invoke("0. Вийти в головне меню");
                OnAdmin.Invoke("Виберіть опцію: ");

                string choice = Console.ReadLine();
                if (choice == "0") break;

                switch (choice)
                {
                    case "1":
                        DeleteOrder();
                        break;
                    case "2":
                        AddNewPizza();
                        break;
                    case "3":
                        SavePizzasToJson();
                        break;
                    default:
                        OnAdmin.Invoke("Некоректний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

   
        public void DeleteOrder()
        {
            LoadOrdersFromJson();
            OnAdmin?.Invoke("Список всіх замовлень:");
            for (int i = 0; i < allOrders.Count; i++)
            {
                OnAdmin.Invoke($"{i + 1}. {allOrders[i]}");
            }

            OnAdmin.Invoke("Виберіть номер замовлення для видалення: ");
            if (int.TryParse(Console.ReadLine(), out int orderNumber) && orderNumber > 0 && orderNumber <= allOrders.Count)
            {
                allOrders.RemoveAt(orderNumber - 1);
                SaveOrdersToJson();
                OnAdmin?.Invoke("Замовлення було успішно видалено.");
            }
            else
            {
                OnAdmin?.Invoke("Некоректний вибір.");
            }
        }

        
        public void AddNewPizza()
        {
            OnAdmin?.Invoke("Введіть назву нової піци:");
            string pizzaName = Console.ReadLine();

            OnAdmin?.Invoke("Введіть ціну нової піци:");
            double pizzaPrice;
            while (!double.TryParse(Console.ReadLine(), out pizzaPrice) || pizzaPrice <= 0)
            {
                OnAdmin?.Invoke("Некоректна ціна, спробуйте ще раз.");
            }
            ProductType Type;
            while (!ProductType.TryParse(Console.ReadLine(), out Type) || pizzaPrice <= 0)
            {
                OnAdmin?.Invoke("Некоректний вибір!");
            }

            allPizzas = LoadPizzasFromJson();

          
            Pizza newPizza = new Pizza(pizzaName, pizzaPrice, Type);
            allPizzas.Add(newPizza);



            OnAdmin?.Invoke("Нова піца успішно додана!");
        }

        private List<Pizza> LoadPizzasFromJson()
        {
            if (!File.Exists(pizzasFile)) return new List<Pizza>();

            string json = File.ReadAllText(pizzasFile);
            return JsonConvert.DeserializeObject<List<Pizza>>(json) ?? new List<Pizza>();
        }

        private void SavePizzasToJson()
        {
            string json = JsonConvert.SerializeObject(allPizzas, Formatting.Indented);
            File.WriteAllText(pizzasFile, json);
            OnAdmin.Invoke("Піци були успішно збережені в файл.");
        }


        private void LoadOrdersFromJson()
        {
            if (File.Exists(ordersFile))
            {
                string json = File.ReadAllText(ordersFile);
                allOrders = JsonConvert.DeserializeObject<List<Order>>(json) ?? new List<Order>();
            }
        }

        private void SaveOrdersToJson()
        {
            string json = JsonConvert.SerializeObject(allOrders, Formatting.Indented);
            File.WriteAllText(ordersFile, json);
        }
    }
}