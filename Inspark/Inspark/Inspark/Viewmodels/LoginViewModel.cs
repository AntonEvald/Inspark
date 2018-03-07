using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Inspark.Viewmodels
{
    class LoginViewModel
    {
        public string Password { get; set; }

        public bool LoginClick()
        {
            var enteredPassword = Password;
            Debug.WriteLine(Password);
            return true;
        }
    }
}
