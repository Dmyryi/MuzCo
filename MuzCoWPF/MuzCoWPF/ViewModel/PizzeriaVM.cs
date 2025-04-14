using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using MuzCoWPF.Model;
using System.Diagnostics;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MuzCoWPF.Utilities;
using MuzCoWPF.Views;

namespace MuzCoWPF.ViewModel
{
   public class PizzeriaVM
    {
        public ObservableCollection<Pizza> Pizzas { get; set; }
        public ObservableCollection<Pizza> Cart { get; set; } = new();

        public ICommand AddToCartCommand { get; }
        public ICommand OpenCartCommand { get; }
        public PizzeriaVM()
        {
            Debug.WriteLine("Переключение на PizzeriaVM");
            Pizzas = LoadPizzas();
            AddToCartCommand = new RelayCommand(AddToCart);
            OpenCartCommand = new RelayCommand(OpenCart);
        }

        private ObservableCollection<Pizza> LoadPizzas()
        {
            string json = File.ReadAllText("C:\\Users\\muzal\\source\\repos\\MuzCoWPF\\MuzCoWPF\\Resources\\data.json");  // Замените на путь к вашему файлу
            var pizzas = JsonConvert.DeserializeObject<List<Pizza>>(json);
            return new ObservableCollection<Pizza>(pizzas);
        }
        public int CartCount => Cart.Count;

        private void AddToCart(object parameter)
        {
            Debug.WriteLine("Нажата кнопка ➤");

            if (parameter is Pizza pizza)
            {
                Debug.WriteLine($"Добавляем пиццу: {pizza.Name}");
                Cart.Add(pizza);
                OnPropertyChanged(nameof(Cart));
                OnPropertyChanged(nameof(CartCount));
            }
            else
            {
                Debug.WriteLine("CommandParameter — не Pizza 😢");
            }
        }


        private void OpenCart(object obj)
        {
            var cartWindow = new CartWindow(Cart);
            cartWindow.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
