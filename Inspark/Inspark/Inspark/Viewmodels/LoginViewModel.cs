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
            var e = email;
            var p = password;
            var a = Password;
            var b = Email;
            if (password != null)
            {
                if (Email != null)
                {
                    var response =  await apiServices.LoginAsync(Email, Password);
                    if (response)
                    {
                        Application.Current.MainPage = new MainPage();
                    }
                }
            }



//            if (!email.Equals("") && !password.Equals(""))
//            {
//                try
//                {
//                    var list = await apiServices.GetAllUsers();
//                    var loginEmail = email;
//                    var result = list.First(user => user.Email == loginEmail);
//                    var dPassword = Encryption.Decrypt(result.Password);
//
//                    if (result.Email == Email && dPassword == Password)
//                    {
//                        Application.Current.MainPage = new MainPage();
//                    }
//                    else
//                    {
//                        AlertMessage = "Fel Email eller lösenord" + Email + Password;
//                    }
//                }
//                catch
//                {
//
//                    AlertMessage = "Fel Email eller lösenord";
//                }
//                     
//            }
//            else
//            {
//                AlertMessage = "Vänligen ange en Email och ett lösenord.";
//            }
        });

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
