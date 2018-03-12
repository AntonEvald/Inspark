using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Windows.Input;
using Inspark.Models;
using Inspark.Services;
using System.Collections;

namespace Inspark.Viewmodels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        ApiServices apiServices = new ApiServices();
        public string Password { get; set; }
        public string Email { get; set; }
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

        //public ICommand LoginClick => new Command(async () =>
        //{
        //    Debug.WriteLine(Email, Password);
        //    if(Email != "" || Email != "Email" || Password != null || Password != "Lösenord")
        //    {
        //        var list = await apiServices.GetAllUsers();
        //        foreach (var user in list)
        //        {
        //            if (user.Email == Email && user.Password == Password)
        //            {
        //                Debug.WriteLine("Ja");
        //            }
        //            else
        //            {
        //                AlertMessage = "Fel Email eller lösenord";
        //            }
        //        }

        //    }
        //    else
        //    {
        //        AlertMessage = "Vänligen ange en Email och ett lösenord.";
        //    }
        //});

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
