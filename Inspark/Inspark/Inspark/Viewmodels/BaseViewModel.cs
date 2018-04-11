using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Inspark.Viewmodels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        // BaseViewModel, of which all other viewmodels will inherit from. This is to spare us the time to write the code more than once. 
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //private void OnPropertyChangedTwo(string property)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        //}
    }
}
