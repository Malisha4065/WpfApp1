using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfApp1.Database;
using WpfApp1.Models;

namespace WpfApp1.ViewModels.Receptionist
{
    public partial class AddPatientVM : ObservableObject
    {
        [ObservableProperty]
        public int patientId;
        [ObservableProperty]
        public string patientName;
        [ObservableProperty]
        public string gender;
        [ObservableProperty]
        public string city;
        [ObservableProperty]
        public string disease;
        [ObservableProperty]
        public DoctorC doctor;
        [ObservableProperty]
        public DateTime date;
        [ObservableProperty]
        public string time;
        [ObservableProperty]
        public string payment;
        [ObservableProperty]
        public string phoneNumber;
        [ObservableProperty]
        ObservableCollection<DoctorC> doctors;

        

        [RelayCommand]
        public void InsertPatient()
        {
            Patient patient = new Patient()
            {
                PatientId = PatientId,
                PatientName = PatientName,
                Gender = Gender,
                City = City,
                Disease = Disease,
                //Doctor = Doctor,
                Date = Date.Date.ToString("d"),
                Time = Time,
                Payment = Payment,
                PhoneNumber = PhoneNumber
            };

            using (var db = new Repository())
            {
                patient.Doctor = db.Doctors.Find(Doctor.DoctorID);
                db.Patients.Add(patient);
                db.SaveChanges();
            }
        }

        public void DoctorList()
        {
            using (var db = new Repository())
            {
                var list = db.Doctors.OrderBy(p => p.Name).ToList();
                Doctors = new ObservableCollection<DoctorC>(list);
            }
        }

        public AddPatientVM()
        {
            DoctorList();    
        }
    }
}
