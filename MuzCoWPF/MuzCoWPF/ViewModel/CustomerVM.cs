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

   public class CustomerVM : ViewModelBase
    {

        private readonly NavigationVM _nav;
        public ObservableCollection<OrderVM> Orders { get; }

        private ProfileSection _currentSection = ProfileSection.None;
        public ProfileSection CurrentSection
        {
            get => _currentSection;
            set { _currentSection = value; OnPropertyChanged(); }
        }

        public ICommand ShowOrdersCommand { get; }
       
        public ICommand ShowFeedbackCommand { get; }
        public ICommand PizzeriaCommand { get; }
        public ICommand ProfileCommand { get; }
        public Customer customer { get; set; }

        public ICommand LogoutCommand { get; }
        private ViewModelBase _currentSubView;
        public ViewModelBase CurrentSubView
        {
            get => _currentSubView;
            set
            {
                _currentSubView = value;
                OnPropertyChanged();
            }
        }

      
        public CustomerVM(NavigationVM navigation, Customer _customer)
        {
            _nav = navigation;
            PizzeriaCommand = NavigationVM.Instance.PizzeriaCommand;
            ShowOrdersCommand = new RelayCommand(_ => CurrentSubView = new OrderHistoryVM(_customer.Id));
            ProfileCommand = new RelayCommand(_=>CurrentSubView = new ProfileVM(_customer));
            ShowFeedbackCommand = new RelayCommand(_ => CurrentSubView = new FeedbackVM(_customer.Id));
            CurrentSubView = new ProfileVM(_customer);
            LogoutCommand = new RelayCommand(_ => Logout());
            customer = _customer;
           
        }

        private void Logout()
        {
            NavigationVM.Instance.CurrentUser = null;
            NavigationVM.Instance.CurrentView = new LogInVM(_nav);
        }

    }
}
