using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfApp1.ViewModels.Admin
{
    public partial class AdminWindowVM : ObservableObject
    {
        public AddUserVM addUserVM { get; set; }
        public ViewUsersVM viewUsersVM { get; set; }
        private object _currentView;

        public object CurrentView { 
            get { return _currentView; } 
            set {  _currentView = value; OnPropertyChanged(); } }

        [RelayCommand]
        public void AddUserForm()
        {
            addUserVM = new AddUserVM();
            CurrentView = addUserVM;
        }

        [RelayCommand]
        public void ViewAllUsers()
        {
            viewUsersVM = new ViewUsersVM();
            CurrentView = viewUsersVM;
        }
    }
}
