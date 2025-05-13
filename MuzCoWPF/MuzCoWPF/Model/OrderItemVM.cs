using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MuzCo;
using MuzCoWPF.Utilities;
using MuzCoWPF.Views;

namespace MuzCoWPF.ViewModel
{
   public class OrderItemVM: ViewModelBase
    {
        private readonly Order order;

        public string OrderId => order.OrderId;
        public string Pizzas => string.Join(", ", order.Pizzas);
        public string TotalPrice => $"{order.TotalPrice:0.00} ₴";
        public string OrderDate => order.OrderDate.ToString("dd.MM.yyyy HH:mm");

        public ICommand LeaveFeedbackCommand { get; }

        public OrderItemVM(Order order)
        {
            this.order = order;

            LeaveFeedbackCommand = new RelayCommand(_ => ShowFeedbackWindow());
        }

        private void ShowFeedbackWindow()
        {
            var window = new LeaveFeedbackWindow(order.OrderId, order.UserId);
            window.ShowDialog();
        }
    }
}
