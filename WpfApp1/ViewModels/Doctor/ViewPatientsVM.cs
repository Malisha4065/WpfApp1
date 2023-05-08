using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using WpfApp1.Database;
using WpfApp1.Messenger;
using WpfApp1.Models;

namespace WpfApp1.ViewModels.Doctor
{
    public partial class ViewPatientsVM : ObservableObject, IRecipient<MessengerC>
    {
        public DoctorC Doctor {  get; set; }

        [ObservableProperty]
        public ObservableCollection<Patient> patients;
        public ViewPatientsVM()
        {
            WeakReferenceMessenger.Default.Register<MessengerC>(this);
        }

        public void Receive(MessengerC message) 
        {
            Doctor = message.Value;
            Patients = new ObservableCollection<Patient>(Doctor.Patients.ToList());
        }
    }
}
