using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzCo
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

        public UserDto(string id, string userName, string password, UserRole role)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Role = role;
        }
    }

}
