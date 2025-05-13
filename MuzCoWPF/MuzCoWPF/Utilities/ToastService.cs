using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzCoWPF.Utilities
{
    public static class ToastService
    {
        public static event Action<string, Action?> ToastRequested;

        public static void Show(string message, Action? onClick = null)
        {
            ToastRequested?.Invoke(message, onClick);
        }
    }

}
