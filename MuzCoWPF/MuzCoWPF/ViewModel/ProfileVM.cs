using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzCo;
using MuzCoWPF.Utilities;

namespace MuzCoWPF.ViewModel
{
   public class ProfileVM : ViewModelBase
    {
        Customer customer;
        public string Username => $"Вітаємо, {customer.UserName}!";
        public ProfileVM(Customer _customer)
        {
          customer = _customer;

        }
    }
}
