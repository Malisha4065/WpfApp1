using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using WpfApp1.Messenger;
using WpfApp1.Models;

namespace WpfApp1.ViewModels.Doctor
{
    public partial class DoctorWindowVM : ObservableObject, IRecipient<MessengerCfirst>
    {
        public ViewPatientsVM viewPatientsVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public DoctorWindowVM()
        {
            WeakReferenceMessenger.Default.Register<MessengerCfirst>(this);
        }

        [RelayCommand]
        public async void ViewAllPatients()
        {
            Task userControlTask = userControlF();

            Task messageTask = sendMessageF();

            await userControlTask;
            await messageTask;
        }
        private async Task userControlF()
        {
            await Task.Delay(100);
            viewPatientsVM = new ViewPatientsVM();
            CurrentView = viewPatientsVM;
        }
        private async Task sendMessageF()
        {
            await Task.Delay(150);
            WeakReferenceMessenger.Default.Send(new MessengerC(Doctor));
        }

        private DoctorC Doctor;
        public void Receive(MessengerCfirst message)
        {
            Doctor = message.Value;
        }
    }
}
