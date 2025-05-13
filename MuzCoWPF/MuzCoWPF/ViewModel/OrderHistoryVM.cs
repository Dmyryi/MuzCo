using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzCo;
using MuzCoWPF.Utilities;

namespace MuzCoWPF.ViewModel
{
   public class OrderHistoryVM : ViewModelBase
    {
        public ObservableCollection<OrderItemVM> Orders { get; }

        public OrderHistoryVM(string userId)
        {
            var orders = Order.GetOrderHistory(userId);
            Debug.WriteLine($"Знайдено замовлень: {orders.Count}");
            foreach (var item in orders) {
                Debug.WriteLine($"[{item.OrderDate}] {string.Join(", ", item.Pizzas)} - {item.TotalPrice} ₴");


            }
            Orders = new ObservableCollection<OrderItemVM>(orders.Select(o => new OrderItemVM(o)));
        }


    }
}
