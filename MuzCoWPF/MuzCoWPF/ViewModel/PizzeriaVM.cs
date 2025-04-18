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

        public ObservableCollection<Pizza> Pizzas { get; set; }
        public ObservableCollection<Pizza> Cart { get; set; }
        public ICommand OpenCartCommand { get; }
        public ICommand AddToCartCommand { get; }

        public PizzeriaVM()
        {
            _pizzeria = new MuzCo.Pizzeria();
            _pizzeria.LoadData("C:\\Users\\muzal\\source\\repos\\MuzCo\\MuzCoWPF\\MuzCoWPF\\Resources\\data.json");
            OpenCartCommand = new RelayCommand(_ => OpenCart());
            Pizzas = new ObservableCollection<Pizza>(_pizzeria.Pizzas);
            Cart = new ObservableCollection<Pizza>();

            AddToCartCommand = new RelayCommand(p => AddToCart(p as Pizza));
        }

        private void AddToCart(Pizza pizza)
        {
            if (pizza == null) return;
            Cart.Add(pizza);
            MessageBox.Show($"✅ Додано в кошик: {pizza.Name}");
        }

        private void OpenCart()
        {
            var window = new CartWindow(Cart);
            window.ShowDialog();
        }
    }
    }
