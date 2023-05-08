using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging.Messages;
using WpfApp1.Models;

namespace WpfApp1.Messenger
{
    public class MessengerC : ValueChangedMessage<DoctorC>
    {
        public MessengerC(DoctorC value) : base(value) { }
    }

    public class MessengerCfirst : ValueChangedMessage<DoctorC>
    {
        public MessengerCfirst(DoctorC value) : base(value) { }
    }
}
