using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using WpfApp1.Database;
using WpfApp1.Models;

namespace WpfApp1.ViewModels.Receptionist
{
    public partial class ViewAllPatientsVM : ObservableObject  
    {
        [ObservableProperty]
        public ObservableCollection<Patient> patients;

        public ViewAllPatientsVM()
        {
            using (var db = new Repository())
            {
                patients = new ObservableCollection<Patient>(db.Patients.Include("Doctor").OrderBy(p => p.PatientId).ToList());
            }
        }
    }
}
