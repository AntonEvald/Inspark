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

namespace Inspark.Viewmodels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        ApiServices apiServices = new ApiServices();
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
        public bool KeepLoggedIn { get; set; }
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
            if (!email.Equals("") && !password.Equals(""))
            {
                try
                {
                    var list = await apiServices.GetAllUsers();
                    var loginEmail = email;
                    var result = list.First(user => user.Email == loginEmail);

                    if (result.Email == Email && result.Password == Password)
                    {
                        Application.Current.MainPage = new MainPage();
                    }
                    else
                    {
                        AlertMessage = "Fel Email eller lösenord" + Email + Password;
                    }
                }
                catch
                {

                    AlertMessage = "Fel Email eller lösenord";
                }
                     
            }
            else
            {
                AlertMessage = "Vänligen ange en Email och ett lösenord.";
            }
        });

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
