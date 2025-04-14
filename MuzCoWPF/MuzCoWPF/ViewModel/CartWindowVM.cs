using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzCoWPF.Model;
using MuzCoWPF.Utilities;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace MuzCoWPF.ViewModel
{
    class CartWindowVM:Utilities.ViewModelBase
    {
        public ObservableCollection<Pizza> Cart { get; set; }

        public ICommand SubmitOrderCommand { get; }

        public CartWindowVM(ObservableCollection<Pizza> cart)
        {
            Cart = cart;
            SubmitOrderCommand = new RelayCommand(SubmitOrder);
        }

        private void SubmitOrder(object obj)
        {
            

            //if (App.CurrentUser == null)
            //{
            //    // Открытие LoginWindow
            //    var login = new LoginWindow();
            //    login.ShowDialog();
            //    if (App.CurrentUser == null)
            //    {
            //        MessageBoxService.Show("Необхідно увійти для оформлення замовлення.", "Увага");
            //        return;
            //    }
            //}

            double total = Cart.Sum(p => p.Price);
            //var order = new Order(App.Id, Cart.ToList(), total, "Очікує підтвердження");

            //OrderService.SaveOrder(order);
            //MessageBoxService.Show("🎉 Замовлення оформлено!", "Успіх");
            Cart.Clear();

            if (obj is Window window)
                window.Close();
        }

        public string TotalPrice => $"{Cart.Sum(p => p.Price)} ₴";
    }
}
