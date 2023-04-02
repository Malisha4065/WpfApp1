using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        public string date;
        [ObservableProperty]
        public string time;
        [ObservableProperty]
        public string payment;
        [ObservableProperty]
        public string phoneNumber;

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
                Doctor = Doctor,
                Date = Date,
                Time = Time,
                Payment = Payment,
                PhoneNumber = PhoneNumber
            };
        }
    }
}
