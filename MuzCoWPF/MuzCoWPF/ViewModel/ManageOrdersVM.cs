using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MuzCo;
using System.Windows.Input;
using System.Windows;
using MuzCoWPF.Utilities;
using Newtonsoft.Json;

namespace MuzCoWPF.ViewModel
{
   public class ManageOrdersVM:ViewModelBase
    {
        private readonly AdminVM _admin;
        public ObservableCollection<Order> Orders { get; set; }
        public ICommand DeleteOrderCommand { get; }

        public ManageOrdersVM(AdminVM admin)
        {
            _admin = admin;
            Orders = new ObservableCollection<Order>(LoadOrdersFromFile());
            DeleteOrderCommand = new RelayCommand(o => DeleteOrder(o as Order));
        }

        private List<Order> LoadOrdersFromFile()
        {
            var path = "C:\\Users\\muzal\\source\\repos\\MuzCo\\MuzCoWPF\\MuzCoWPF\\Resources\\orders.json";
            if (!File.Exists(path)) return new List<Order>();
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<Order>>(json) ?? new List<Order>();
        }

        private void SaveOrdersToFile()
        {
            var path = "C:\\Users\\muzal\\source\\repos\\MuzCo\\MuzCoWPF\\MuzCoWPF\\Resources\\orders.json";
            var json = JsonConvert.SerializeObject(Orders, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        private void DeleteOrder(Order order)
        {
            if (order == null) return;
            Orders.Remove(order);
            SaveOrdersToFile();
            MessageBox.Show("✅ Замовлення видалено");
        }
    }
}
