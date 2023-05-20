using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Internal;
using WpfApp1.Database;
using WpfApp1.Models;

namespace WpfApp1.ViewModels.Admin
{
    public partial class ViewUsersVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<User> users;

        private User selectedUser;

        public User SelectedUser
        {
            get {
                return selectedUser;
            }
            set {
                User user = value;
                if (selectedUser == null)
                    selectedUser = new User();
                if (user != null)
                {
                    selectedUser.UserId = user.UserId;
                    selectedUser.UserName = user.UserName;
                    selectedUser.Password = user.Password;
                    selectedUser.Occupation = user.Occupation;
                }
                else
                {
                    selectedUser = value;
                }
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        public ViewUsersVM()
        {
            using (var db = new Repository())
            {
                users = new ObservableCollection<User>(db.Users.OrderBy(u => u.UserName).ToList());
            }
        }

        [RelayCommand]
        public void UpdateUser()
        {
            if (SelectedUser != null) 
            {
                using (var db = new Repository())
                {
                    User user = db.Users.Find(SelectedUser.UserId);
                    user.UserName = SelectedUser.UserName;
                    user.Password = SelectedUser.Password;
                    user.Occupation = SelectedUser.Occupation;

                    db.SaveChanges();

                    Users = new ObservableCollection<User>(db.Users.OrderBy(u => u.UserName).ToList());
                }
            }
            else
            {
                MessageBox.Show("Please Select a User");
            }
        }
    }
}
