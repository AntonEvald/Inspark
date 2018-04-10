using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Windows.Input;
using Inspark.Models;
using Inspark.Views;
using Inspark.Services;
using System.Linq;
using System.Collections;
using System.Net;
using Inspark.Helpers;

namespace Inspark.Viewmodels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private ApiServices _api = new ApiServices();

        private string _password = "";

        public string Password
        {
            get { return _password; }
            set
            {
                if(_password != value)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
                
            }
        }

        private string _email = "";

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        private bool _keepLoggedIn;

        public bool KeepLoggedIn
        { 
            get 
            {
                return _keepLoggedIn;
            } set
            {
                _keepLoggedIn = value;
                OnPropertyChanged("KeepLoggedIn");
            } 
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged("IsLoading");
                }
            }
        }

        private string _alertMessage;

        public string AlertMessage
        {
            get { return _alertMessage; }
            set
            {
                if(_alertMessage != value)
                {
                    _alertMessage = value;
                    OnPropertyChanged("AlertMessage");
                }
            }
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public ICommand LoginClick => new Command(async () =>
        {
            if (_password != null)
            {
                if (Email != null)
                {
                    IsLoading = true;
                    var response =  await _api.LoginAsync(Email, Password);
                    if (response)
                    {
                        if (Settings.UserName != Email)
                        {
                            Settings.UserName = Email;
                            Settings.UserPassword = Password;
                        }
                        IsLoading = false;
                        Application.Current.MainPage = new MainPage();
                    }
                    else
                    {
                        IsLoading = false;
                        AlertMessage = "Fel Email eller lösenord";
                    }
                }
            }
        });

        public LoginViewModel()
        {
            Email = Settings.UserName;
            Password = Settings.UserPassword;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
