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
    public partial class ReceptionistWindowVM : ObservableObject
    {
        public AddPatientVM addPatientVM { get; set; }
        private object _currentView;

		public object CurrentView
		{
			get { return _currentView; }
			set { _currentView = value;
				OnPropertyChanged();
			}
		}
        
        [RelayCommand]
        public void AddPatientForm ()
        {
            addPatientVM = new AddPatientVM();
            CurrentView = addPatientVM;
        }

        public ReceptionistWindowVM()
        {
           /* addPatientVM = new AddPatientVM();
            CurrentView = addPatientVM;*/
        }
    }
}
