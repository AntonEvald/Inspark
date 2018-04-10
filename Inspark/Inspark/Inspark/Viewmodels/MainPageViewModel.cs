using Inspark.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Inspark.Viewmodels
{
    class MainPageViewModel : BaseViewModel
    {
        private ApiServices _api = new ApiServices();

        private string _user;

        public string User
        {
            get { return _user; }
            set
            {
                if(_user != value)
                {
                    _user = value;
                    OnPropertyChanged();
                }
            }
        }

        public async void OnLoad()
        {
            var user = await _api.GetLoggedInUser();
            string userName = user.UserName;
            User = userName;
        }

        public MainPageViewModel()
        {
            //OnLoad();
        }

    }
}
