using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzCo
{
   public abstract class User
    {
        public string Id { get;private set; }
        public string UserName { get; private set; }
        public string Password { get;private set; }
        public UserRole UserRole { get;private set; }

        public static List<User> LoadUser(string filePath) {
            throw new ArgumentException("Invalid file path", nameof(filePath));
        }

        public static void SaveUser(User Users, string filePath) {
            throw new ArgumentException("Invalid user or file path", nameof(Users));
        }

        public static User LogIn(string filePath, string inputUser, string inputPass) {
            throw new ArgumentException("Invalid login parameters", nameof(inputUser));
        }

        public static User Register(string filePath, string newUser, string newPass) {
            throw new ArgumentException("Invalid registration parameters", nameof(newUser));
        }

        public virtual void ShowMenu(User user) {
            throw new ArgumentException("Invalid user", nameof(user));
        }
    }
}
