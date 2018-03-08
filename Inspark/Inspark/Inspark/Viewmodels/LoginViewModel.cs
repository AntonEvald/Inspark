using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Windows.Input;

namespace Inspark.Viewmodels
{
    public class LoginViewModel : ICommand
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public bool KeepLoggedIn { get; set; }

        public LoginViewModel()
        {

        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
