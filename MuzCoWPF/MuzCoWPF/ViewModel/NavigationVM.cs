using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzCoWPF.Utilities;
using System.Windows.Input;
using MuzCoWPF.Views;

namespace MuzCoWPF.ViewModel
{
    class NavigationVM:Utilities.ViewModelBase
    {
        private object _currentView;

        public object CurrentView { get { return _currentView; } set { _currentView = value; OnPropertyChanged(); } }

        public ICommand HomeCommand { get; set; }
        public ICommand CustomerCommand { get; set;}
        public ICommand AdminCommand {  get; set;}
        public ICommand LogInCommand {  get; set;}
        public ICommand PizzeriaCommand { get; set;}
        public ICommand RegisterCommand { get; set;}
        public ICommand StatusOrderCommand { get; set;}


        private void Home(object obj) => CurrentView = new HomeVM(this);
        private void Admin(object obj) => CurrentView = new AdminVM();
        private void Customer(object obj) => CurrentView = new CustomerVM();
        private void LogIn(object obj)=>CurrentView = new LogInVM();
        private void Pizzeria(object obj)=>CurrentView =new PizzeriaVM();
        private void Register(object obj)=>CurrentView =new RegisterVM();
        private void StatusOrder(object obj)=>CurrentView =new StatusOrderVM();

        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            AdminCommand = new RelayCommand(Admin);
            CustomerCommand = new RelayCommand(Customer);
           LogInCommand = new RelayCommand(LogIn);
            PizzeriaCommand= new RelayCommand(Pizzeria);
            RegisterCommand = new RelayCommand(Register);
            StatusOrderCommand = new RelayCommand(StatusOrder);

            CurrentView = new HomeVM(this);

        }
    }
}
