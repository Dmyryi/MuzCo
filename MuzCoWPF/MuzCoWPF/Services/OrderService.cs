using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Controls;

using System.IO;

namespace MuzCoWPF.Services
{
    public static class OrderService
    {
        private static readonly string file = "orders.json";

        //public static void SaveOrder(Order order)
        //{
        //    List<Order> orders = new();

        //    if (File.Exists(file))
        //    {
        //        string json = File.ReadAllText(file);
        //        orders = JsonConvert.DeserializeObject<List<Order>>(json) ?? new();
        //    }

        //    orders.Add(order);
        //    File.WriteAllText(file, JsonConvert.SerializeObject(orders, Formatting.Indented));
        //}
    }
}
