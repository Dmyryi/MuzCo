using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using MuzCo;
using MuzCoWPF.Utilities;
using Newtonsoft.Json;

namespace MuzCoWPF.ViewModel
{
    public class LogInVM : ViewModelBase
    {
        private readonly NavigationVM _nav;
        private Customer _customer;
        private string _username;
        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand LogInCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand PizzeriaCommand { get; }

        public LogInVM(NavigationVM navigation)
        {
            _nav = navigation;

            User.OnUserLoggedIn += msg => MessageBox.Show(msg);
            User.OnLogInFailed += msg => MessageBox.Show("⛔ " + msg);
            User.OnRegisteredIn += msg => MessageBox.Show("✅ " + msg);
            User.OnRegisteredFailed += msg => MessageBox.Show("⚠️ " + msg);

            LogInCommand = new RelayCommand(_ => ExecuteLogIn());
            RegisterCommand = new RelayCommand(_ => ExecuteRegister());
            PizzeriaCommand = NavigationVM.Instance.PizzeriaCommand;
        }

        private void ExecuteLogIn()
        {
            var user = User.LogIn("C:\\Users\\muzal\\source\\repos\\MuzCo\\MuzCoWPF\\MuzCoWPF\\Resources\\users.json", Username, Password);
            var users = User.LoadUser("C:\\Users\\muzal\\source\\repos\\MuzCo\\MuzCoWPF\\MuzCoWPF\\Resources\\users.json");

            foreach (var us in users)
            {
                Debug.WriteLine($"👤 {us.UserName} | {us.Password} | Role: {us.UserRole}");
            }


            if (user != null)
            {
                MessageBox.Show($"Роль: {user.UserName} → {user.UserRole}");



                Customer customer = user as Customer;

                NavigationVM.Instance.CurrentUser = customer;
                if (user.UserRole == UserRole.Admin)
                 
                _nav.CurrentView = new AdminVM(_nav, customer);
                else
                {
                  
                
                    _nav.CurrentView = new CustomerVM(_nav, customer);

                }
                   
                
            }
        }

        private void ExecuteRegister()
        {
            string path = "C:\\Users\\muzal\\source\\repos\\MuzCo\\MuzCoWPF\\MuzCoWPF\\Resources\\users.json";

            var user = User.Register(path, Username, Password);

            if (user != null && user is Customer customer)
            {
                NavigationVM.Instance.CurrentUser = customer;
                _nav.CurrentView = new CustomerVM(_nav, customer);
            }
        }
    }
}
