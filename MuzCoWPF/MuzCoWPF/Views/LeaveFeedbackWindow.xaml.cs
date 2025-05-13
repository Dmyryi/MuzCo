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
using System.Windows.Shapes;
using MuzCo;
using MuzCoWPF.Utilities;

namespace MuzCoWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для LeaveFeedbackWindow.xaml
    /// </summary>
    public partial class LeaveFeedbackWindow : Window
    {
        private readonly string orderId;
        private readonly string userId;

        private Validator feedbackValidator;

        public LeaveFeedbackWindow(string orderId, string userId)
        {
            InitializeComponent();
            this.orderId = orderId;
            this.userId = userId;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string text = FeedbackTextBox.Text.Trim();

            if (!Validator.ValidateAll(text, out string message))
            {
                MessageBox.Show(message);
                return;
            }


            var feedback = new Feedback(orderId, userId, text, DateTime.Now);
            feedback.AddReview();

            MessageBox.Show("Дякуємо за відгук!", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
