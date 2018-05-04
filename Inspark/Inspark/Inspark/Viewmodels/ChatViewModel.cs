using Inspark.Helpers;
using Inspark.Models;
using Inspark.Services;
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
    public class ChatViewModel : BaseViewModel
    {
        ApiServices _api = new ApiServices();

        private ObservableRangeCollection<Message> _messages;

        public ObservableRangeCollection<Message> Messages { get; } = new ObservableRangeCollection<Message>();


        private string _outgoingText = string.Empty;

        public string OutGoingText
        {
            get { return _outgoingText; }
            set
            {
                _outgoingText = value;
                OnPropertyChanged();
            }
        }

        public ICommand RefreshCommand => new Command(() =>
        {
            IsRefreshing = true;
            Messages.ReplaceRange(_messages);
            IsRefreshing = false;
        });

        public bool IsRefreshing { get; set; }

        public User User { get; set; }

        public ICommand SendCommand => new Command(() =>
       {
           var message = new Message
           {
               Text = OutGoingText,
               IsIncoming = false,
               MessageDateTime = DateTime.Now,
               SenderPic = User.ProfilePicture,
               SenderId = User.Id
           };
           Messages.Add(message);
           OutGoingText = string.Empty;
           _messages = Messages;
       });


        public ICommand LocationCommand { get; set; }

        public ChatViewModel()
        {
            OnLoad();
        }

        async void OnLoad()
        {
            User = await _api.GetLoggedInUser();
            InitializeMock();
        }


        public void InitializeMock()
        {
            Messages.ReplaceRange(new ObservableRangeCollection<Message>
                {
                    new Message { Text = "Hi Squirrel! \uD83D\uDE0A", IsIncoming = true, MessageDateTime = DateTime.Now.AddMinutes(-25), SenderPic = User.ProfilePicture },
                    new Message { Text = "Hi Baboon, How are you? \uD83D\uDE0A", IsIncoming = false, MessageDateTime = DateTime.Now.AddMinutes(-24), SenderPic = User.ProfilePicture },
                    new Message { Text = "We've a party at Mandrill's. Would you like to join? We would love to have you there! \uD83D\uDE01", IsIncoming = true, MessageDateTime = DateTime.Now.AddMinutes(-23), SenderPic = User.ProfilePicture },
                    new Message { Text = "You will love it. Don't miss.", IsIncoming = true, MessageDateTime = DateTime.Now.AddMinutes(-23), SenderPic = User.ProfilePicture },
                    new Message { Text = "Sounds like a plan. \uD83D\uDE0E", IsIncoming = false, MessageDateTime = DateTime.Now.AddMinutes(-23), SenderPic = User.ProfilePicture },
                    new Message { Text = "\uD83D\uDE48 \uD83D\uDE49 \uD83D\uDE49", IsIncoming = false, MessageDateTime = DateTime.Now.AddMinutes(-23), SenderPic = User.ProfilePicture },

            });
        }
    }
}
