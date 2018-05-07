using Inspark.Helpers;
using Inspark.Models;
using Inspark.Services;
using MvvmHelpers;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace Inspark.Viewmodels
{
    public class ChatViewModel : BaseViewModel
    {
        private ObservableRangeCollection<Message> _messages = new ObservableRangeCollection<Message>();

        public ObservableRangeCollection<Message> Messages
        {
            get { return _messages; } 
            set
            {
                _messages = value;
                OnPropertyChanged();
            }
        } 


        private string _outgoingText = string.Empty;

        public string OutgoingText
        {
            get { return _outgoingText; }
            set
            {
                _outgoingText = value;
                OnPropertyChanged();
            }
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; OnPropertyChanged(); }
        }


        public User User { get; set; }

        public User OtherDude { get; set; }

        public ICommand SendCommand { get; set; }

        public ICommand RefreshCommand => new Command(() =>
        {
            RefreshMessages();
        });

        void RefreshMessages()
        {
            IsLoading = true;

            IsLoading = false;
        }

        public ChatViewModel()
        {
            OnLoad();
            SendCommand = new Command(() =>
            {
                var message = new Message
                {
                    Text = OutgoingText,
                    IsIncoming = false,
                    MessageDateTime = DateTime.Now,
                    SenderPic = User.ProfilePicture,
                    SenderId = User.Id,
                    ReciverId = OtherDude.Id
                };
                Messages.Add(message);
                OutgoingText = string.Empty;
            });
            
        }

        public ChatViewModel(User user, User reciver)
        {
            SendCommand = new Command(() =>
            {
                var message = new Message
                {
                    Text = OutgoingText,
                    IsIncoming = false,
                    MessageDateTime = DateTime.Now,
                    SenderPic = User.ProfilePicture,
                    SenderId = User.Id,
                    ReciverId = OtherDude.Id
                };
                Messages.Add(message);
                OutgoingText = string.Empty;
            });
            User = user;
            OtherDude = reciver;
        }

        async void OnLoad()
        {
            User = await _api.GetLoggedInUser();
            OtherDude = User;
            InitializeMock();
        }


        public void InitializeMock()
        {
            Messages.ReplaceRange(new List<Message>
            {
                    new Message { Text = "Yo my dude! \uD83D\uDE0A", IsIncoming = true, MessageDateTime = DateTime.Now.AddMinutes(-25), SenderPic = User.ProfilePicture },
                    new Message { Text = "Hi Baboon, How are you? \uD83D\uDE0A", IsIncoming = false, MessageDateTime = DateTime.Now.AddMinutes(-24), SenderPic = User.ProfilePicture },
                    new Message { Text = "Who the fuck u callin a baboon mate??? \uD83D\uDE01", IsIncoming = true, MessageDateTime = DateTime.Now.AddMinutes(-23), SenderPic = User.ProfilePicture },
                    new Message { Text = "Ya fuckin babbon ass lookin fucker, shut the fuck up!", IsIncoming = false, MessageDateTime = DateTime.Now.AddMinutes(-23), SenderPic = User.ProfilePicture },
                    new Message { Text = "You better watch ur mouth befor i fuck it my dude \uD83D\uDE0E", IsIncoming = true, MessageDateTime = DateTime.Now.AddMinutes(-23), SenderPic = User.ProfilePicture },
                    new Message { Text = "\uD83D\uDE48 \uD83D\uDE49 \uD83D\uDE49", IsIncoming = false, MessageDateTime = DateTime.Now.AddMinutes(-23), SenderPic = User.ProfilePicture },

            });

            Messages.Add(new Message
            {
                Text = "Hej",
                IsIncoming = false,
                MessageDateTime = DateTime.Now,
                SenderId = User.Id,
                SenderPic = User.ProfilePicture
            });
        }
    }
}
