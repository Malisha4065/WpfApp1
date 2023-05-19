using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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
            get { return selectedUser; }
            set { 
                if (value != null)
                    selectedUser = value;
                modifiedUser.UserName = selectedUser.UserName;
                modifiedUser.Password = selectedUser.Password;
                modifiedUser.Occupation = selectedUser.Occupation;
                OnPropertyChanged(nameof(ModifiedUser));
            }
        }


        private User modifiedUser;
        public User ModifiedUser { 
            get {
                return modifiedUser;
            } 
            set
            {
                modifiedUser = value;
            }
        }

        public ViewUsersVM()
        {
            using (var db = new Repository())
            {
                users = new ObservableCollection<User>(db.Users.OrderBy(u => u.UserName).ToList());
            }

            modifiedUser = new User();
        }

        [RelayCommand]
        public void UpdateUser()
        {
            using (var db = new Repository())
            {
                User user = db.Users.Find(SelectedUser.UserName);
                user.UserName = ModifiedUser.UserName;
                user.Password = ModifiedUser.Password;
                user.Occupation = ModifiedUser.Occupation;
                
                db.SaveChanges();
            }
            using (var db = new Repository())
            {
                Users = new ObservableCollection<User>(db.Users.OrderBy(u => u.UserName).ToList());
            }
            SelectedUser = null;
        }
    }
}
