using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzCoWPF.Utilities;
using System.Windows.Input;
using MuzCoWPF.Views;
using MuzCo;

namespace MuzCoWPF.ViewModel
{
    public class NavigationVM:Utilities.ViewModelBase
    {
        private object _currentView;
        public static NavigationVM Instance { get; private set; }

        public object CurrentView { get { return _currentView; } set { _currentView = value; OnPropertyChanged(); } }
        public User CurrentUser { get; set; }

        public ICommand HomeCommand { get; set; }
        public ICommand CustomerCommand { get; set;}
        public ICommand AdminCommand {  get; set;}
        public ICommand LogInCommand {  get; set;}
        public ICommand PizzeriaCommand { get; set;}
        public ICommand RegisterCommand { get; set;}
        public ICommand StatusOrderCommand { get; set;}
        public ICommand ProfileCommand { get; }
        public Customer CurrentCustomer { get; set;}

        private void Home(object obj) => CurrentView = new HomeVM(this);
        private void Admin(object obj) => CurrentView = new AdminVM(this, CurrentCustomer);
        private void Customer(object obj) => CurrentView = new CustomerVM(this, CurrentCustomer);
        private void LogIn(object obj) => CurrentView = new LogInVM(this);

        private void Pizzeria(object obj)=>CurrentView =new PizzeriaVM(this);
        private void Register(object obj)=>CurrentView =new RegisterVM();
        private void StatusOrder(object obj)
        {
            if (obj is Order order)
            {
                CurrentView = new StatusOrderVM(order);
            }
        }

        private void OpenProfile()
        {
            if (CurrentUser is Customer customer)
            {
                CurrentView = new CustomerVM(this, customer);
            }
            else
            {
                CurrentView = new LogInVM(this);
            }
        }

        public NavigationVM()
        {
            Instance = this;
            HomeCommand = new RelayCommand(Home);
            AdminCommand = new RelayCommand(Admin);    
            CustomerCommand = new RelayCommand(Customer);
           LogInCommand = new RelayCommand(LogIn);
            PizzeriaCommand= new RelayCommand(Pizzeria);
            RegisterCommand = new RelayCommand(Register);
            StatusOrderCommand = new RelayCommand(StatusOrder);
            ProfileCommand = new RelayCommand(_ => OpenProfile());
            CurrentView = new HomeVM(this);

        }
    }
}
