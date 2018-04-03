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
        private ApiServices apiServices = new ApiServices();
        private string password = "";

        public string Password
        {
            get { return password; }
            set
            {
                if(password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
                
            }
        }


        private string email = "";
        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        private bool keepLoggedIn;
        public bool KeepLoggedIn
        { 
            get 
            {
                return keepLoggedIn;
            } set
            {
                keepLoggedIn = value;
                OnPropertyChanged("KeepLoggedIn");
            } 
        }

        private bool isLoading;

        public bool IsLoading
        {
            get { return isLoading; }
            set
            {
                if (isLoading != value)
                {
                    isLoading = value;
                    OnPropertyChanged("IsLoading");
                }
            }
        }

        private string alertMessage;

        public string AlertMessage
        {
            get { return alertMessage; }
            set
            {
                if(alertMessage != value)
                {
                    alertMessage = value;
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
            if (password != null)
            {
                if (Email != null)
                {
                    IsLoading = true;
                    var response =  await apiServices.LoginAsync(Email, Password);
                    if (response)
                    {
                        if (Settings.UserName == "")
                        {
                            Settings.UserName = Email;
                            Settings.UserPassword = Password;
                        }
                        Settings.KeepLoggedIn = KeepLoggedIn;
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
