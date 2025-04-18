using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MuzCoWPF.ViewModel;

namespace MuzCoWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для Pizzeria.xaml
    /// </summary>
    public partial class Pizzeria : UserControl
    {
        public Pizzeria()
        {
            InitializeComponent();
            DataContext = new PizzeriaVM();
        }

        private void OpenCart_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is PizzeriaVM vm)
            {
                //var window = new CartWindow(vm.Cart);
                //window.ShowDialog();
            }
        }

    }
}
