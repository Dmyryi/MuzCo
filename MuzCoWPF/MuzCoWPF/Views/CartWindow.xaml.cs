using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MuzCoWPF.Model;
using MuzCoWPF.ViewModel;

namespace MuzCoWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        private readonly ObservableCollection<Pizza> _cart;
        public CartWindow(ObservableCollection<Pizza> cart)
        {
            InitializeComponent();

            DataContext = new CartWindowVM(cart);
        }


        private void UpdateTotal()
        {
            double total = _cart.Sum(p => p.Price);
            TotalAmountText.Text = $"{total} ₴";
        }

        private void SubmitOrder_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("🎉 Замовлення оформлено!", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
