using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using WpfApp1.Database;
using WpfApp1.Messenger;
using WpfApp1.Models;

namespace WpfApp1.ViewModels.Doctor
{
    public partial class AddReportVM : ObservableObject, IRecipient<MessengerDoctorReportDoc>
    {
        [ObservableProperty]
        public string patientName;
        [ObservableProperty]
        public string chiefComplaint;
        [ObservableProperty]
        public DateTime dateOfBirth;
        [ObservableProperty]
        public DateTime date;
        [ObservableProperty]
        public bool isSurgeryRequired;
        [ObservableProperty]
        public DateTime dateOfSurgery;
        [ObservableProperty]
        public ObservableCollection<bool> medicalHistory;
        [ObservableProperty]
        public bool anyPastSurgeries;
        [ObservableProperty]
        public ObservableCollection<string> hospitals;
        [ObservableProperty]
        public ObservableCollection<string> years;
        [ObservableProperty]
        public ObservableCollection<string> complications;
        [ObservableProperty]
        public string diagnosis;
        [ObservableProperty]
        public bool anyMedications;
        [ObservableProperty]
        public string medications;
        [ObservableProperty]
        public string additionalNotes;

        [ObservableProperty]
        public ObservableCollection<Patient> patients;
        [ObservableProperty]
        public Patient selectedPatient;
    
        public DoctorC doctor;

        public AddReportVM()
        {
            WeakReferenceMessenger.Default.Register<MessengerDoctorReportDoc>(this);
            //PatientList();
        }

        /*private void PatientList() 
        {
            using (var db = new Repository())
            {
                var list = db.Doctors.Find(doctor.DoctorID).Patients.OrderBy(p => p.PatientName).ToList();
                Patients = new ObservableCollection<Patient>(list);
            }
        }*/

        [RelayCommand]
        public void ReportSubmit()
        {
            try
            {
                using (var db = new Repository())
                {
                    DoctorReport doctorReport = new DoctorReport()
                    {
                        Doctor = doctor,
                        Patient = SelectedPatient,
                        PatientName = PatientName,
                        ChiefComplaint = ChiefComplaint,
                        DateOfBirth = DateOfBirth.Date.ToString("d"),
                        Date = Date.Date.ToString("d"),
                        IsSurgeryRequired = IsSurgeryRequired,
                        DateOfSurgery = DateOfSurgery.Date.ToString("d"),
                        AnyPastSurgeries = AnyPastSurgeries,
                        Diagnosis = Diagnosis,
                        AnyMedication = AnyMedications,
                        Medications = Medications,
                        AdditionalNotes = AdditionalNotes
                    };

                    string medicalString = JsonSerializer.Serialize(MedicalHistory);
                    doctorReport.MedicalString = medicalString;
                    string hospitalsString = JsonSerializer.Serialize(Hospitals);
                    doctorReport.Hospitals = hospitalsString;
                    string yearsString = JsonSerializer.Serialize(Years);
                    doctorReport.Years = yearsString;
                    string complicationsString = JsonSerializer.Serialize(Complications);
                    doctorReport.Complications = complicationsString;

                    db.DoctorReports.Add(doctorReport);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
        }

        public void Receive(MessengerDoctorReportDoc message)
        {
            doctor = message.Value;
            Patients = new ObservableCollection<Patient>(doctor.Patients.ToList());
        }
    }
}
