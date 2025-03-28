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

        public User(string id, string userName, string password, UserRole role)
        {
            throw new NotImplementedException();
        }

        public static List<User> LoadUser(string filePath) {
            throw new NotImplementedException();
        }

        public static void SaveUser(User Users, string filePath) {
            throw new NotImplementedException();
        }

        public static User LogIn(string filePath, string inputUser, string inputPass) {
            throw new NotImplementedException();
        }

        public static User Register(string filePath, string newUser, string newPass) {
            throw new NotImplementedException();
        }

        public virtual void ShowMenu(User user) {
            throw new NotImplementedException();
        }
    }
}
