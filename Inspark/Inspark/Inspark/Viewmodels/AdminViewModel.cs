using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Inspark.Viewmodels
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }


    }
}
