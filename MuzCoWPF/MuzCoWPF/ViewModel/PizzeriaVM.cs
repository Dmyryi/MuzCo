using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

using System.Diagnostics;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MuzCoWPF.Utilities;
using MuzCoWPF.Views;
using MuzCo;
using MuzCoWPF.Utilities;
using System.Windows;
namespace MuzCoWPF.ViewModel
{
    public class PizzeriaVM:ViewModelBase
    {
        private readonly MuzCo.Pizzeria _pizzeria;
        private readonly LogIn _login;
        private ProductType selectedCategory = ProductType.Pizza;

        public ProductType SelectedCategory
        {
            get => selectedCategory;
            set
            {
                selectedCategory = value;
                OnPropertyChanged();
                FilterProducts();
            }
        }


        public ObservableCollection<string> Cities { get; } = new ObservableCollection<string>
{
    "Київ", "Львів", "Харків", "Одеса", "Дніпро"
};

        private string _selectedCity = "Київ";
        public string SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                OnPropertyChanged();
            
            }
        }

        public ICommand SetCategoryCommand { get; }

        public ObservableCollection<Pizza> Pizzas { get; set; }
        public ObservableCollection<Pizza> FilteredProducts { get; set; }
        public ObservableCollection<Pizza> Cart { get; set; }
        public double TotalPrice => Cart.Sum(p => p.Price);
        public ICommand OpenCartCommand { get; }
        public ICommand AddToCartCommand { get; }
        public ICommand ConfirmOrderCommand { get; }
        public ICommand GoToProfileCommand { get; }
        public ICommand RemoveFromCartCommand { get; }
        public ICommand LogInCommand { get; }
        public Customer customer { get; set; }
        public PizzeriaVM(NavigationVM navigation)
        {
      
            _pizzeria = new MuzCo.Pizzeria();
            customer = navigation.CurrentUser as Customer;
            if (customer != null)
            {
                Debug.WriteLine($"🔐 Вхід виконано. Користувач: {customer.UserName}, ID: {customer.Id}");
            }
            else
            {
                Debug.WriteLine("❌ Користувач не авторизований.");
            }

            RemoveFromCartCommand = new RelayCommand(obj => RemoveFromCart(obj));

            GoToProfileCommand = NavigationVM.Instance.ProfileCommand;

            ConfirmOrderCommand = new RelayCommand(_ => ConfirmOrder());

            _pizzeria.LoadData("C:\\Users\\muzal\\source\\repos\\MuzCo\\MuzCoWPF\\MuzCoWPF\\Resources\\data.json");
            OpenCartCommand = new RelayCommand(_ => OpenCart());

            Pizzas = new ObservableCollection<Pizza>(_pizzeria.Pizzas);
   
            FilteredProducts = new ObservableCollection<Pizza>();     

           
            Cart = new ObservableCollection<Pizza>();
            SelectedCategory = ProductType.Pizza;
            FilterProducts();
            AddToCartCommand = new RelayCommand(p => AddToCart(p as Pizza));
            SetCategoryCommand = new RelayCommand(param =>
            {
                if (Enum.TryParse(param?.ToString(), out ProductType category))
                    SelectedCategory = category;
            });

            MuzCo.Pizzeria.OnStatusUpdated += (status, order) =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    new ToastWindow("✅Готується", () =>
                    {
                        NavigationVM.Instance.CurrentView = new StatusOrderVM(order);
                    }).Show();

                });
            };
            Pizzas = new ObservableCollection<Pizza>(_pizzeria.Pizzas);


            FilteredProducts = new ObservableCollection<Pizza>();

           
            SelectedCategory = ProductType.Pizza;
        }

        private void RemoveFromCart(object obj)
        {
            if (obj is Pizza pizza)
            {
                Cart.Remove(pizza);
                OnPropertyChanged(nameof(TotalPrice));
            }
        }


        private void OpenCart()
        {
            var window = new CartWindow
            {
                DataContext = this
            };
            window.ShowDialog();
        }

        private void AddToCart(Pizza pizza)
        {
            if (pizza == null) return;
            Cart.Add(pizza);
            MessageBox.Show($"✅ Додано в кошик: {pizza.Name}");
        }

        private bool IsUserAuthorized()
        {
            return customer != null;
        }


        public void FilterProducts()
        {

            FilteredProducts.Clear();

            var filtered = Pizzas.Where(p=>p.Type == selectedCategory).ToList();
           
            foreach (var product in filtered) {
                FilteredProducts.Add(product);
            }
        }

        private void ConfirmOrder()
        {
            if (!IsUserAuthorized())
            {
                MessageBox.Show("Щоб оформити замовлення, потрібно увійти в акаунт.", "Увага", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!Cart.Any())
            {
                MessageBox.Show("Ваш кошик порожній.", "Увага", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var order = new Order
            {
                OrderId = Guid.NewGuid().ToString(),
                UserId = customer.Id,
                Pizzas = Cart.Select(p => p.Name).ToList(),
                TotalPrice = Cart.Sum(p => p.Price),
                OrderDate = DateTime.Now
            };
            _pizzeria.SaveOrder(order);
            NavigationVM.Instance.CurrentView = new StatusOrderVM(order);
            Task.Run(async () => await _pizzeria.UpdateOrderStatus(order));
            Cart.Clear();
            MessageBox.Show("Замовлення успішно оформлено!", "Дякуємо", MessageBoxButton.OK, MessageBoxImage.Information);
        }
     

    }
}
