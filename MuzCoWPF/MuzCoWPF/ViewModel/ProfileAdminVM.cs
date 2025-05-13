using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzCo;
using MuzCoWPF.Utilities;

namespace MuzCoWPF.ViewModel
{
   public class ProfileAdminVM : ViewModelBase
    {
        private AdminVM _admin;
        public string Username => $"Вітаємо, адміністраторе!";
        public ProfileAdminVM(AdminVM admin)
        {
         _admin = admin;

        }
    }
}
