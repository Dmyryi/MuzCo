using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using MuzCo;
using MuzCoWPF.Utilities;

namespace MuzCoWPF.ViewModel
{
    public class AddPizzaVM : ViewModelBase
    {
        private AdminVM _admin;

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
                Debug.WriteLine($"📝 Name changed: {name}");
            }
        }

        private string imagePath;
        public string ImagePath
        {
            get => imagePath;
            set
            {
                imagePath = value;
                OnPropertyChanged();
            }
        }



        private string price;
        public string Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged();
                Debug.WriteLine($"💰 Price changed: {price}");
            }
        }

        private string typeText;
        public string TypeText
        {
            get => typeText;
            set
            {
                typeText = value;
                OnPropertyChanged();
                Debug.WriteLine($"🍕 Type changed: {typeText}");
            }
        }

        public ProductType SelectedType { get; set; } = ProductType.Pizza;

        public ICommand AddPizzaCommand { get; }
        public ICommand SelectImageCommand { get; }
        public ICommand SaveCommand { get; }

        public AddPizzaVM(AdminVM admin)
        {
            _admin = admin;
            Debug.WriteLine("🚀 AddPizzaVM initialized");

            AddPizzaCommand = new RelayCommand(_ =>
            {
                Debug.WriteLine("📦 AddPizzaCommand triggered");
                AddPizza();
            });

            SaveCommand = new RelayCommand(_ =>
            {
                Debug.WriteLine("💾 SaveCommand triggered");
                Save();
            });
            SelectImageCommand = new RelayCommand(_ => SelectImage());
        }

        private void SelectImage()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg";
            if (dialog.ShowDialog() == true)
            {
                ImagePath = dialog.FileName;
                Debug.WriteLine($"🖼️ Обрано зображення: {ImagePath}");
            }
        }

        private void AddPizza()
        {
            Debug.WriteLine("Executing AddPizza");

            // Парсим цену
            if (!double.TryParse(Price, out double parsedPrice))
            {
                MessageBox.Show("❌ Введена некоректна ціна.");
                return;
            }

            // Парсим тип
            if (!Enum.TryParse(TypeText, out ProductType parsedType))
            {
                MessageBox.Show("❌ Невірний тип продукту. Введіть: Pizza, Sauce або Drink.");
                return;
            }

            // Создаём объект пиццы
            var newPizza = new Pizza(Name, parsedPrice, parsedType)
            {
                Image = ImagePath
            };

            // Валидируем
            if (!Validator.IsValidPizza(newPizza, out string validationMessage))
            {
                MessageBox.Show(validationMessage);
                return;
            }

            // Добавляем
            _admin.Pizzas.Add(newPizza);

            Debug.WriteLine($"✅ Pizza added: {Name}, {parsedPrice}, {parsedType}");
            MessageBox.Show("✅ Піца додана!");

            // Очищаем поля
            Name = string.Empty;
            Price = string.Empty;
            TypeText = string.Empty;
        }


        private void Save()
        {
            Debug.WriteLine("🔽 Executing Save");
            _admin.SavePizzasToFile();
            Debug.WriteLine("✅ Menu saved to JSON");
            MessageBox.Show("💾 Меню збережено.");
        }
    }
}
