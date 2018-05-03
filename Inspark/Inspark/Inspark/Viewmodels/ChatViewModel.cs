using Inspark.Helpers;
using Inspark.Models;
using MvvmHelpers;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace Inspark.Viewmodels
{
    public class ChatViewModel : MvvmHelpers.BaseViewModel
    {
        public ObservableRangeCollection<Message> Messages { get; }

        string outgoingText = string.Empty;

        public string OutGoingText
        {
            get { return outgoingText; }
            set { SetProperty(ref outgoingText, value); }
        }

        public ICommand SendCommand => new Command(() =>
       {
           var message = new Message
           {
               Text = OutGoingText,
               IsIncoming = false,
               MessageDateTime = DateTime.Now
           };


           Messages.Add(message);
           OutGoingText = string.Empty;
       });


        public ICommand LocationCommand { get; set; }

        public ChatViewModel()
        {
            Messages = new ObservableRangeCollection<Message>();
            InitializeMock();
        }


        public void InitializeMock()
        {
            Messages.ReplaceRange(new List<Message>
                {
                    new Message { Text = "Hi Squirrel! \uD83D\uDE0A", IsIncoming = true, MessageDateTime = DateTime.Now.AddMinutes(-25)},
                    new Message { Text = "Hi Baboon, How are you? \uD83D\uDE0A", IsIncoming = false, MessageDateTime = DateTime.Now.AddMinutes(-24)},
                    new Message { Text = "We've a party at Mandrill's. Would you like to join? We would love to have you there! \uD83D\uDE01", IsIncoming = true, MessageDateTime = DateTime.Now.AddMinutes(-23)},
                    new Message { Text = "You will love it. Don't miss.", IsIncoming = true, MessageDateTime = DateTime.Now.AddMinutes(-23)},
                    new Message { Text = "Sounds like a plan. \uD83D\uDE0E", IsIncoming = false, MessageDateTime = DateTime.Now.AddMinutes(-23)},
                    new Message { Text = "\uD83D\uDE48 \uD83D\uDE49 \uD83D\uDE49", IsIncoming = false, MessageDateTime = DateTime.Now.AddMinutes(-23)},

            });
        }
    }
}
