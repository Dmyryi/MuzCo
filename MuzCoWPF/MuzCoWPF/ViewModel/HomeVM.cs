using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzCoWPF.Utilities;
using MuzCoWPF.Views;
using System.Windows.Input;

namespace MuzCoWPF.ViewModel
{
    class HomeVM:Utilities.ViewModelBase
    {
        public ICommand PizzeriaCommand { get; }

        public HomeVM(NavigationVM navigation)
        {
            PizzeriaCommand = navigation.PizzeriaCommand;
        }
    }
}
