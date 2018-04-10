using Inspark.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Inspark.Viewmodels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        private ApiServices _api = new ApiServices();
        
        public event PropertyChangedEventHandler PropertyChanged;

        private string _user;

        public string User
        {
            get { return _user; }
            set
            {
                if(_user != value)
                {
                    _user = value;
                    OnPropertyChanged("User");
                }
            }
        }

        public async void OnLoad()
        {
            var user = await _api.GetLoggedInUser();
            string userName = user.UserName;
            User = userName;
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public MainPageViewModel()
        {
            //OnLoad();
        }

    }
}
