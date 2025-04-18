using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzCo;
using MuzCoWPF.Utilities;
using System.Windows.Input;
using MuzCoWPF.ViewModel;


namespace MuzCoWPF.ViewModel
{
    public enum ProfileSection
    {
        None,
        Orders,
        Favorites,
        Feedback
    }

    class CustomerVM : ViewModelBase
    {
        public string Username => $"Вітаємо, {CurrentSession.UserName}!";

        public ObservableCollection<OrderVM> Orders { get; }

        private ProfileSection _currentSection = ProfileSection.None;
        public ProfileSection CurrentSection
        {
            get => _currentSection;
            set { _currentSection = value; OnPropertyChanged(); }
        }

        public ICommand ShowOrdersCommand { get; }
        public ICommand ShowFavoritesCommand { get; }
        public ICommand ShowFeedbackCommand { get; }

        public CustomerVM()
        {
            ShowOrdersCommand = new RelayCommand(_ => CurrentSection = ProfileSection.Orders);
            ShowFavoritesCommand = new RelayCommand(_ => CurrentSection = ProfileSection.Favorites);
            ShowFeedbackCommand = new RelayCommand(_ => CurrentSection = ProfileSection.Feedback);

            // Заказы предварительно загружаем
            Orders = new ObservableCollection<OrderVM>(
                Order.GetOrderHistory(CurrentSession.UserId)
                    .Select(o => new OrderVM(o))
            );
        }
    }
}
