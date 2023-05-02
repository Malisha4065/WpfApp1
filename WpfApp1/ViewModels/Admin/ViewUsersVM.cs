using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using WpfApp1.Database;
using WpfApp1.Models;

namespace WpfApp1.ViewModels.Admin
{
    public partial class ViewUsersVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<User> users;

        public ViewUsersVM()
        {
            using (var db = new Repository())
            {
                users = new ObservableCollection<User>(db.Users.OrderBy(u => u.UserName).ToList());
            }
        }
    }
}
