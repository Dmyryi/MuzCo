using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Guid;

namespace MuzCo
{
    public abstract class User
    {
        public string Id { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public UserRole UserRole { get; private set; }

        public static event Action<string> OnUserLoggedIn;
        public static event Action<string> OnLogInFailed;
        public static event Action<string> OnRegisteredIn;
        public static event Action<string> OnRegisteredFailed;

        public User(string id, string userName, string password, UserRole role)
        {
            Id = id;
            UserName = userName;
            Password = password;
            UserRole = role;
        }

        public static List<User> LoadUser(string filePath)
        {
            if (!File.Exists(filePath)) return new List<User>();

            string json = File.ReadAllText(filePath);
            var userList = JsonConvert.DeserializeObject<List<UserDto>>(json) ?? new List<UserDto>();

            List<User> users = new List<User>();
            foreach (var u in userList)
            {
                if (u.Role == UserRole.Admin)
                {
                    users.Add(new Admin(u.Id, u.UserName, u.Password));
                }
                else
                {
                    users.Add(new Customer(u.Id, u.UserName, u.Password));
                }
            }

            return users;
        }

        public static void SaveUser(List<User> users, string filePath)
        {
            var userDtoList = users.Select(u => new UserDto(u.Id, u.UserName, u.Password, u.UserRole)).ToList();
            string json = JsonConvert.SerializeObject(userDtoList, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static User LogIn(string filePath, string inputUser, string inputPass)
        {
           
            if (!IsValidUserName(inputUser))
            {
                OnLogInFailed?.Invoke("❌ Невірне ім'я користувача! Використовуйте від 3 до 20 літер та цифр.");
                return null;
            }

            if (!IsValidPassword(inputPass))
            {
                OnLogInFailed?.Invoke("❌ Невірний формат пароля! Мінімум 6 символів, хоча б одна літера і цифра.");
                return null;
            }

            List<User> users = LoadUser(filePath);
            var user = users.FirstOrDefault(u => u.UserName == inputUser && u.Password == inputPass);
            if (user != null)
            {
                OnUserLoggedIn?.Invoke($"✅ Привіт {user.UserName}!");
                return user;
            }

            OnLogInFailed?.Invoke("❌ Помилка авторизації. Невірний логін або пароль.");
            return null;
        }

        public static User Register(string filePath, string newUser, string newPass)
        {
            
            if (!IsValidUserName(newUser))
            {
                OnRegisteredFailed?.Invoke("❌ Ім'я користувача має містити від 3 до 20 літер та цифр.");
                return null;
            }

            if (!IsValidPassword(newPass))
            {
                OnRegisteredFailed?.Invoke("❌ Пароль має містити мінімум 6 символів, хоча б одну літеру і цифру.");
                return null;
            }

            List<User> users = LoadUser(filePath);

            if (users.Any(u => u.UserName == newUser))
            {
                OnRegisteredFailed?.Invoke("❌ Ім'я вже зайнято!");
                return null;
            }

            User newUserObj = new Customer(Guid.NewGuid().ToString(), newUser, newPass);
            users.Add(newUserObj);
            SaveUser(users, filePath);

            OnRegisteredIn?.Invoke($"✅ Успішна реєстрація! Привіт {newUser}!");
            return newUserObj;
        }

        public virtual void ShowMenu(User user)
        {
        }

       

        private static bool IsValidUserName(string username)
        {
            return Regex.IsMatch(username, @"^[a-zA-Z0-9]{3,20}$");
        }

        private static bool IsValidPassword(string password)
        {
            return password.Length >= 6 &&
                   password.Any(char.IsLetter) &&
                   password.Any(char.IsDigit) &&
                   !password.Any(char.IsWhiteSpace);
        }
    }
}
