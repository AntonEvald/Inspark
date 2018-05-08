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

        public ICommand SendCommand => new Command(() =>
        {
            var message = new Message
            {
                Text = OutgoingText,
                IsIncoming = false,
                MessageDateTime = DateTime.Now,
                SenderPic = User.ProfilePicture,
                SenderId = User.Id,
            };
            _messages.Add(message);
            OutgoingText = string.Empty;
        });

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
           _messages.Add(new Message { Text = "Hej!", IsIncoming = false, MessageDateTime= DateTime.Now, SenderPic = User.ProfilePicture });
        }
    }
}
