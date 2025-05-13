using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzCo
{
    public class Customer : User
    {
        public static event Action<string> UserMenu;

        private Pizzeria pizzeria;
        private Order order;
    
        private Feedback feedback;

        public Customer(string id, string userName, string password, UserRole role)
       : base(id, userName, password, role)
        {
            pizzeria = new Pizzeria();
            order = new Order();
            feedback = new Feedback();
        }




        public override void ShowMenu(User registeredUser)
        {
            while (true)
            {
                UserMenu?.Invoke("1. Залишити відгук");
                UserMenu?.Invoke("2. Переглянути історію замовлень");
                UserMenu?.Invoke("3. Замовити піцу");
                UserMenu?.Invoke("0. Вийти в головне меню");
                UserMenu?.Invoke("Оберіть опцію: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        while (true)
                        {
                            var reviewsOrders = feedback.GetReviewsByUser(registeredUser.Id);
                            foreach (var review in reviewsOrders)
                            {
                                UserMenu?.Invoke(review.ToString());
                            }

                            var userOrders = Order.GetOrderHistory(registeredUser.Id);

                            if (userOrders.Count == 0)
                            {
                                UserMenu?.Invoke("❌ У вас ще немає замовлень для написання відгуку.");
                                break;
                            }

                            UserMenu?.Invoke("Оберіть замовлення, на яке хочете залишити відгук:");
                            int indexOrder = 1;
                            foreach (var o in userOrders)
                            {
                                UserMenu?.Invoke($"{indexOrder}. {o}");
                                indexOrder++;
                            }

                            UserMenu?.Invoke("Введіть номер замовлення: ");
                            if (!int.TryParse(Console.ReadLine(), out int orderIndex) || orderIndex < 1 || orderIndex > userOrders.Count)
                            {
                                UserMenu?.Invoke("❌ Неправильний вибір. Спробуйте ще раз.");
                                continue;
                            }

                            var selectedOrder = userOrders[orderIndex - 1];

                            string reviewText;
                            while (true)
                            {
                                UserMenu?.Invoke("Введіть ваш відгук: ");
                                reviewText = Console.ReadLine();

                                if (string.IsNullOrWhiteSpace(reviewText))
                                {
                                    UserMenu?.Invoke("❌ Відгук не може бути порожнім. Спробуйте ще раз.");
                                    continue;
                                }
                                if (reviewText.Length <= 5)
                                {
                                    UserMenu?.Invoke("❌ Відгук не може бути порожнім. Спробуйте ще раз.");
                                    continue;
                                }
                                if (!reviewText.Any(char.IsLetter))
                                {
                                    UserMenu?.Invoke("❌ Відгук має містити хоча б одну літеру. Спробуйте ще раз.");
                                    continue;
                                }
                                break; // Если все ок – выходим из цикла
                            }

                            var reviews = new Feedback(selectedOrder.OrderId, registeredUser.Id, reviewText, DateTime.Now);
                            reviews.AddReview();

                            UserMenu?.Invoke("✅ Ваш відгук додано!");
                            break;
                        }
                        break;

                    case "2":
                        var historyOrder = Order.GetOrderHistory(registeredUser.Id);
                        if (historyOrder.Count == 0)
                        {
                            UserMenu?.Invoke("❌ У вас немає історії замовлень.");
                        }
                        else
                        {
                            foreach (Order orders in historyOrder)
                            {
                                UserMenu?.Invoke(orders.ToString());
                            }
                        }
                        break;

                    case "3":
                        pizzeria.LoadData("data.json");
                        pizzeria.CreateOrder(registeredUser.Id);
                        break;

                    case "0":
                        return;

                    default:
                        UserMenu?.Invoke("❌ Невідома команда. Спробуйте ще раз.");
                        break;
                }
            }
        }

    }
}
 