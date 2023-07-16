using FluentAssertions;
using WpfApp1.Messenger;
using WpfApp1.Models;
using WpfApp1.ViewModels.Doctor;

namespace WpfApp1.tests
{
    public class UnitTest1
    {
        // For WpfApp1.ViewModels.Doctor.OverviewVM.cs
        [Fact]
        public void Should_Initialize_CorrectOverviewProperties()
        {
            // Arrange
            var overviewVM = new OverviewVM();
            var doctor = new DoctorC()
            {
                Patients = new List<Patient> { },
            };
            var patient1 = new Patient();
            var patient2 = new Patient();
            patient1.Payment = "100";
            patient1.Date = "2023-07-16";
            patient2.Payment = "200";
            patient2.Date = "2023-07-17";
            doctor.Patients.Add(patient1);
            doctor.Patients.Add(patient2);

            overviewVM.doctor = doctor; 

            var expectedTotalPatients = doctor.Patients.Count;
            var expectedTotalPayment = doctor.Patients.Sum(patient => int.Parse(patient.Payment));
            var expectedUpcomingAppointments = doctor.Patients.Count(appointment => DateTime.Parse(appointment.Date) >= DateTime.Today);

            // Act
            overviewVM.Initializer();

            // Assert
            overviewVM.TotalPatients.Should().Be(expectedTotalPatients);
            overviewVM.TotalPayment.Should().Be(expectedTotalPayment);
            overviewVM.UpcomingAppointments.Should().Be(expectedUpcomingAppointments);
        }
    }
}