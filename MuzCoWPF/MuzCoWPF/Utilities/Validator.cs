using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzCo;

namespace MuzCoWPF.Utilities
{
    class Validator
    {
        public static bool IsNotEmpty(string text, out string message)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                message = "❌ Відгук не може бути порожнім. Спробуйте ще раз.";
                return false;
            }

            message = string.Empty;
            return true;
        }

        public static bool IsLongEnough(string text, out string message)
        {
            if (text.Length <= 5)
            {
                message = "❌ Відгук занадто короткий. Напишіть більше деталей.";
                return false;
            }

            message = string.Empty;
            return true;
        }

        public static bool ContainsLetters(string text, out string message)
        {
            if (!text.Any(char.IsLetter))
            {
                message = "❌ Відгук має містити хоча б одну літеру. Спробуйте ще раз.";
                return false;
            }

            message = string.Empty;
            return true;
        }

        public static bool ValidateAll(string text, out string message)
        {
            if (!IsNotEmpty(text, out message)) return false;
            if (!IsLongEnough(text, out message)) return false;
            if (!ContainsLetters(text, out message)) return false;
            return true;
        }

        public static bool IsValidPizza(Pizza pizza, out string message)
        {
            if (pizza == null)
            {
                message = "❌ Піца не може бути null.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(pizza.Name))
            {
                message = "❌ Назва піци не може бути порожньою.";
                return false;
            }

            if (pizza.Name.Length < 3)
            {
                message = "❌ Назва піци занадто коротка.";
                return false;
            }

            if (pizza.Price <= 0)
            {
                message = "❌ Ціна піци повинна бути більшою за 0.";
                return false;
            }

            if (!Enum.IsDefined(typeof(ProductType), pizza.Type))
            {
                message = "❌ Тип продукту вказано некоректно.";
                return false;
            }

            message = string.Empty;
            return true;
        }
    }
}
