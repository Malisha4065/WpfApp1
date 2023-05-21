using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfApp1.Database;
using WpfApp1.Models;

namespace WpfApp1.ViewModels.Admin
{
    public partial class AddUserVM : ObservableObject
    {
        public string UserName { get; set; }
        public string Password { private get; set; }
        public string ReEnteredPassword { private get; set; }
        public string Occupation { get; set; }

        [RelayCommand]
        public void SubmitNewUser ()
        {
            if (Password == ReEnteredPassword)
            {
                User user = new User()
                {
                    UserName = UserName,
                    Password = Password,
                    Occupation = Occupation
                };

                using (Repository repo = new Repository())
                {
                    repo.Users.Add(user);
                    repo.SaveChanges();
                }

                MessageBox.Show("User Added Successfully");
            }
            else
            {
                MessageBox.Show("Passwords don't match!");
            }
            
        }
    }
}
