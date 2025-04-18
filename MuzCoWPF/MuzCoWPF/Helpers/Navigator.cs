using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MuzCoWPF.Helpers
{
  public static class Navigator
    {
        public static void Navigate(UserControl page)
        {
            if(Application.Current.MainWindow is MainWindow main)
            {
                main.MainContent.Content = page;
            }
        }
    }
}
