using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzCo;
using MuzCoWPF.Utilities;
using System.Windows.Input;
using System.Windows;

namespace MuzCoWPF.ViewModel
{
 //   class CartWindowVM : ViewModelBase
 //   {
 //       public ObservableCollection<Pizza> Cart { get; }
 //       public ICommand PlaceOrderCommand { get; }

 //       public event Action<decimal> TotalUpdated;

 //       public CartWindowVM(ObservableCollection<Pizza> cart)
 //       {
 //           Cart = cart;
 //           PlaceOrderCommand = new RelayCommand(_ => PlaceOrder());
 //           UpdateTotal();
 //           Cart.CollectionChanged += (_, __) => UpdateTotal();
 //       }

 //       private void UpdateTotal()
 //       {
 //           decimal total = (decimal)Cart.Sum(p => p.Price);
 //           TotalUpdated?.Invoke(total);
 //       }

 //       private void PlaceOrder()
 //       {
 //           if (!Cart.Any())
 //           {
 //               MessageBox.Show("🛒 Кошик порожній!");
 //               return;
 //           }

 //           var order = new Order(
 //    CurrentSession.UserId,
 //    Cart.Select(p => p.Name).ToList(), // <== вот это важно!
 //    Cart.Sum(p => p.Price),
 //    "Очікує"
 //);

 //           Order.OnOrderPlaced += msg => MessageBox.Show(msg);
 //           order.Place();

 //           Cart.Clear();
 //           UpdateTotal();
 //       }
 //   }
}
