using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfApp1.Database;
using WpfApp1.Models;

namespace WpfApp1.ViewModels.Doctor
{
    public partial class AddReportVM : ObservableObject
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

        [RelayCommand]
        public void ReportSubmit()
        {
            try
            {
                using (var db = new Repository())
                {
                    DoctorReport doctorReport = new DoctorReport()
                    {
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

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
        }
    }
}
