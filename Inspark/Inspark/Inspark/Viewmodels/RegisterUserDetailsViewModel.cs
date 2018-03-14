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
using System.IO;

namespace Inspark.Viewmodels
{
    class RegisterUserDetailsViewModel : INotifyPropertyChanged
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public byte[] ProfilePic { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand RegisterCommand => new Command(async () =>
        {
            Stream stream = await DependencyService.Get<IPhotoPicker>().GetImageStreamAsync();

            if(stream != null)
            {
                
            }
        });
    }
}
