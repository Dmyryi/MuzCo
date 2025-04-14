using System.Text;
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


namespace MuzCoWPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new NavigationVM();
    }


    private void CloseWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        this.Close();
    }

    // Сворачивание окна
    private void MinimizeWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    // Развертывание окна
    private void MaximizeWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if (this.WindowState == WindowState.Normal)
        {
            this.WindowState = WindowState.Maximized;
        }
        else
        {
            this.WindowState = WindowState.Normal;
        }
    }

    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            // Включаем перетаскивание окна
            this.DragMove();
        }
    }
}