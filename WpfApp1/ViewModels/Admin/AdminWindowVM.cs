﻿using System;
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
        public AddDoctorVM addDoctorVM { get; set; }
        public ViewDoctorsVM viewDoctorsVM { get; set; }

        private readonly WindowFactory windowFactory;
        public Action CloseAction { get; set; }

        private object _currentView;

        public object CurrentView { 
            get { return _currentView; } 
            set {  _currentView = value; OnPropertyChanged(); } }

        public AdminWindowVM()
        {
            windowFactory = new ProductionWindowFactory();
        }

        [RelayCommand]
        public void LogOut()
        {
            windowFactory.CreateNewMainWindow();
            CloseAction();
        }

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

        [RelayCommand]
        public void AddDoctorForm()
        {
            addDoctorVM = new AddDoctorVM();
            CurrentView = addDoctorVM;
        }

        [RelayCommand]
        public void ViewAllDoctors()
        {
            viewDoctorsVM = new ViewDoctorsVM();
            CurrentView = viewDoctorsVM;
        }
    }
}
