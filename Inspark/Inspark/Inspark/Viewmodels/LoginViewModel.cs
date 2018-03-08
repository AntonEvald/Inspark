using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Windows.Input;
using Inspark.Models;
using System.Collections;

namespace Inspark.Viewmodels
{
    public class LoginViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private string _password;
        public string Password {
            get
            {
                return _password;
            }
            set
            {
                if(_password != value)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        private string _Email;

        public string Email
        {
            get { return _Email; }
            set
            {
                if (_Email != value)
                {
                    _Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        private bool keepLoggedIn;

        public bool KeepLoggedIn
        {
            get { return keepLoggedIn; }
            set
            {
                if (keepLoggedIn != value)
                {
                    keepLoggedIn = value;
                    OnPropertyChanged("KeepLoggedIn");
                }
            }
        }
        public ICommand LoginClick { get; private set; }

        public bool HasErrors => throw new NotImplementedException();

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public LoginViewModel()
        {
            LoginClick = new Command (ValidateLogin);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        void ValidateLogin()
        {
            var listofusers = new List<User>();
            var user = new User
            {
                Email = "anton@evald.se",
                Password = "hej"
            };
            listofusers.Add(user);

            foreach(var x in listofusers)
            {
                if(x.Email == Email && x.Password == Password)
                {
                    Debug.WriteLine("Funkar");
                }
                else
                {
                    Debug.WriteLine("Funkar");
                }
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
