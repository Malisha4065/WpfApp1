using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfApp1.Database;
using WpfApp1.Models;

namespace WpfApp1.ViewModels.Admin
{
    public partial class AddDoctorVM : ObservableObject
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string Password { get; set; }
        public string ReEnteredPassword { get; set; }

        [RelayCommand]
        public void SubmitNewDoctor()
        {
            if (Password == ReEnteredPassword)
            {
                User user = new User()
                {
                    UserName = UserName,
                    Password = Password,
                    Occupation = "Doctor"
                };

                DoctorC doctor = new DoctorC()
                {
                    Name = Name,
                    Specialization = Specialization
                };

                using (Repository repo = new Repository())
                {
                    repo.Users.Add(user);
                    repo.SaveChanges();

                    doctor.DoctorID = user.UserId;

                    repo.Doctors.Add(doctor);
                    repo.SaveChanges();
                }

                MessageBox.Show("Doctor Added Successfully");
            }
            else
            {
                MessageBox.Show("Password don't match!");
            }
        }

    }
}
