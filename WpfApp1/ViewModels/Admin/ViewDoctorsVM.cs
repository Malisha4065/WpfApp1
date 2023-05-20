using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using WpfApp1.Database;
using WpfApp1.Models;

namespace WpfApp1.ViewModels.Admin
{
    public partial class ViewDoctorsVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<DoctorC> doctors;

        private DoctorC selectedDoctor;

        public DoctorC SelectedDoctor
        {
            get
            {
                return selectedDoctor;
            }
            set
            {
                DoctorC doctor = value;
                if (selectedDoctor == null)
                    selectedDoctor = new DoctorC();
                if (doctor != null)
                {
                    selectedDoctor.DoctorID = doctor.DoctorID;
                    selectedDoctor.Name = doctor.Name;
                    selectedDoctor.Specialization = doctor.Specialization;
                }
                else
                {
                    selectedDoctor = value;
                }
                OnPropertyChanged(nameof(SelectedDoctor));
            }
        }

        public ViewDoctorsVM()
        {
            using (var db = new Repository())
            {
                doctors = new ObservableCollection<DoctorC>(db.Doctors.OrderBy(d => d.DoctorID).ToList()); 
            }
        }

        [RelayCommand]
        public void UpdateDoctor()
        {
            if (selectedDoctor != null)
            {
                using (var db = new Repository())
                {
                    DoctorC doctor = db.Doctors.Find(SelectedDoctor.DoctorID);
                    doctor.Name = SelectedDoctor.Name;
                    doctor.Specialization = SelectedDoctor.Specialization;

                    db.SaveChanges();

                    Doctors = new ObservableCollection<DoctorC>(db.Doctors.OrderBy(d => d.DoctorID).ToList());
                }
            }
            else
            {
                MessageBox.Show("Please Select a Doctor");
            }
        }
    }
}
