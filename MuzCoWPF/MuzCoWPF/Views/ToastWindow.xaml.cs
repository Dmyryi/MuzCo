using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MuzCoWPF.Views
{
    public partial class ToastWindow : Window
    {
        private Action? _onClick;

        public ToastWindow(string message, Action? onClick = null)
        {
            InitializeComponent();
            ToastText.Text = message;
            _onClick = onClick;

            this.Owner = Application.Current.MainWindow; // 🔒

            Loaded += (s, e) =>
            {
                Window main = Application.Current.MainWindow;
                Left = main.Left + main.Width - Width - 20;
                Top = main.Top + 20;

                Task.Delay(5000).ContinueWith(_ =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        if (IsLoaded) Close(); // ✅ безопасное закрытие
                    });
                });
            };
        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _onClick?.Invoke();
            if (IsLoaded) Close(); // ✅ и тут
        }
    }

}
