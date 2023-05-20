﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;
using WpfApp1.Database;
using WpfApp1.Messenger;
using WpfApp1.Models;

namespace WpfApp1.ViewModels.Receptionist
{
    public partial class ViewAllPatientsVM : ObservableObject  
    {
        [ObservableProperty]
        public ObservableCollection<Patient> patients;

        [ObservableProperty]
        public Patient selectedPatient;

        public ViewAllPatientsVM()
        {
            using (var db = new Repository())
            {
                patients = new ObservableCollection<Patient>(db.Patients.Include("Doctor").OrderBy(p => p.PatientId).ToList());
            }
        }

        [RelayCommand]
        public void UpdatePatient()
        {
            if (SelectedPatient != null)
            {
                WeakReferenceMessenger.Default.Send(new MessengerPatientToEditFirst(SelectedPatient));
            }
            else
            {
                MessageBox.Show("Please Select a Patient to Update");
            }
        }
    }
}
