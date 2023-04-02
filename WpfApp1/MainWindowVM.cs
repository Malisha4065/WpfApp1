using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using Microsoft.EntityFrameworkCore.Query;
using WpfApp1.Database;

namespace WpfApp1
{
    public partial class MainWindowVM : ObservableObject
    {
        public string Logo { 
            get
            {
                return $"/Icons/medicine.png";
            }
        }

        //[ObservableProperty]
        
        public string Username { get; set; }
        public string Password { private get; set; }
        


        public bool isUserNameAvailable()
        {
            using (Repository repo = new Repository())
            {
                if (repo.Users.Find(Username) == null)
                    return false;
                else
                    return true;
            }
        }

        public bool isPasswordCorrect()
        {
            using (Repository repo = new Repository())
            {
                if (repo.Users.Find(Username).Password != Password)
                    return false;
                else
                    return true;
            }
        }




        [RelayCommand]
        public void loginClicked()
        {
            if (isUserNameAvailable())
            {
                if (isPasswordCorrect())
                {
                    MessageBox.Show("Permission Granted");
                }
                else
                {
                    MessageBox.Show("Wrong Password");
                }
            }
            else
            {
                MessageBox.Show("Wrong Username");
            }
        }
    }
}
