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
    public partial class ViewDoctorsVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<DoctorC> doctors;

        public ViewDoctorsVM()
        {
            using (var db = new Repository())
            {
                doctors = new ObservableCollection<DoctorC>(db.Doctors.OrderBy(d => d.DoctorID).ToList());
            }
        }
    }
}
