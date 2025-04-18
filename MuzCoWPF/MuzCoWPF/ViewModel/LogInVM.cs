using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using MuzCoWPF.Utilities;
using MuzCo;
using System.Windows;

namespace MuzCoWPF.ViewModel
{
    public class LogInVM:ViewModelBase
    {

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

        public LogInVM()
        {
            Debug.WriteLine("Переключение на LogInVM");

            User.OnUserLoggedIn += msg => MessageBox.Show(msg);
            User.OnLogInFailed += msg => MessageBox.Show("⛔ " + msg);
            User.OnRegisteredIn += msg => MessageBox.Show("✅ " + msg);
            User.OnRegisteredFailed += msg => MessageBox.Show("⚠️ " + msg);

            LogInCommand = new RelayCommand(_ => ExecuteLogIn());
            RegisterCommand = new RelayCommand(_ => ExecuteRegister());

        }

        private void ExecuteLogIn()
        {
            User.LogIn(Username, Password, "users.json");
        }

        private void ExecuteRegister()
        {
            User.Register(Username, Password, "users.json");
        }
    }
}
