using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzCo;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        string usersFile = "users.json";
        string dataFile = "data.json";
        bool isStart = true;


        User.OnRegisteredIn += message => Console.WriteLine(message);
        User.OnUserLoggedIn += message => Console.WriteLine(message);
        User.OnLogInFailed += message => Console.WriteLine(message);
        User.OnRegisteredFailed += message => Console.WriteLine(message);
        Customer.UserMenu += message => Console.WriteLine(message);
        Feedback.OnReviewsPlaced += message => Console.WriteLine(message);
        Admin.OnAdmin += message => Console.WriteLine(message);
        Pizzeria.UserMenu += message => Console.WriteLine(message);
        Order.OnOrderPlaced += message => Console.WriteLine(message);

        User currentUser = null;

        while (isStart)
        {
            Console.WriteLine("\n🍕 Ласкаво просимо в піццерію! 🍕");
            Console.WriteLine("\n  1. 📜 Показати меню");
            Console.WriteLine("  2. 🔑 Увійти");
            Console.WriteLine("  3. 📝 Зареєструватись");
            Console.WriteLine("  0. 🚪 Вийти");

            Console.Write("\n👉 Оберіть дію: ");
            string choice = Console.ReadLine();
            Pizzeria pizzeria = new Pizzeria();

            switch (choice)
            {
                case "1":
                    pizzeria.LoadData(dataFile);
                    break;

                case "2":
                    while (true)
                    {
                        Console.Write("\n🔑 Ім'я користувача (0 - назад): ");
                        string username = Console.ReadLine();
                        if (username == "0") break;

                        Console.Write("🔒 Пароль: ");
                        string password = Console.ReadLine();
                        if (password == "0") break;
                        currentUser = User.LogIn(usersFile, username, password);
                        if (currentUser != null)
                        {
                            currentUser.ShowMenu(currentUser);
                            break;
                        }

                        Console.WriteLine("❌ Повторіть спробу входа.");
                    }
                    break;

                case "3":
                    while (true)
                    {
                        Console.Write("\n🔑 Ім'я користувача (0 - назад): ");
                        string newUsername = Console.ReadLine();
                        if (newUsername == "0") break;



                        Console.Write("🔒 Пароль: ");
                        string newPassword = Console.ReadLine();
                        if (newPassword == "0") break;
                        currentUser = User.Register(usersFile, newUsername, newPassword);
                        if (currentUser != null)
                        {
                            currentUser.ShowMenu(currentUser);
                            break;
                        }

                        Console.WriteLine("❌ Повторіте спробу реєстрації.");
                    }
                    break;

                case "0":
                    isStart = false;
                    break;

                default:
                    Console.WriteLine("❌ Невірний вибір! Спробуйте ще раз.");
                    break;
            }
        }
    }
}
