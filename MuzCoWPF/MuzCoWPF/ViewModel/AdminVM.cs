using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzCo;
using System.Windows.Input;
using MuzCoWPF.Utilities;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace MuzCoWPF.ViewModel
{
    public enum AdminSection
    {
        None,
        Orders,
        AddPizza,
        SaveJson
    }


    public class AdminVM:ViewModelBase
    {
        private readonly NavigationVM _nav;
        private ViewModelBase _currentAdminView;
        public ViewModelBase CurrentAdminView
        {
            get => _currentAdminView;
            set
            {
                _currentAdminView = value;
                Debug.WriteLine($"🔁 CurrentAdminView => {_currentAdminView?.GetType().Name}");
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Pizza> Pizzas { get; set; } = new ObservableCollection<Pizza>();
        public ICommand ShowAddPizzaCommand { get; }
        public ICommand ShowOrdersCommand { get; }
        public ICommand ProfileCommand { get; }
        public Customer customer { get; set; }
        public ICommand PizzeriaCommand { get; }

        public AdminVM(NavigationVM nav, Customer _customer)
        {
            customer = _customer;
            _nav = nav;
            ShowAddPizzaCommand = new RelayCommand(_ =>
            {
                Debug.WriteLine("➡ Перехід на AddPizzaVM");
                CurrentAdminView = new AddPizzaVM(this);
            });
            ShowOrdersCommand = new RelayCommand(_ => CurrentAdminView = new ManageOrdersVM(this));
            ProfileCommand = new RelayCommand(_ => CurrentAdminView = new ProfileAdminVM(this));
            CurrentAdminView = new AddPizzaVM(this);
                  PizzeriaCommand = NavigationVM.Instance.PizzeriaCommand;
        }
        public void SavePizzasToFile()
        {
            string path = "C:\\Users\\muzal\\source\\repos\\MuzCo\\MuzCoWPF\\MuzCoWPF\\Resources\\data.json";

            List<Pizza> existingPizzas = new List<Pizza>();

            if (File.Exists(path))
            {
                string existingJson = File.ReadAllText(path);
                existingPizzas = JsonConvert.DeserializeObject<List<Pizza>>(existingJson) ?? new List<Pizza>();
            }

            // Уникаємо дублювання (наприклад, по імені піци)
            foreach (var newPizza in Pizzas)
            {
                if (!existingPizzas.Any(p => p.Name == newPizza.Name))
                {
                    existingPizzas.Add(newPizza);
                }
            }

            string updatedJson = JsonConvert.SerializeObject(existingPizzas, Formatting.Indented);
            File.WriteAllText(path, updatedJson);
        }

    }
}
