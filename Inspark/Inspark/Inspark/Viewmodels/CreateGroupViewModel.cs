using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Inspark.Annotations;

namespace Inspark.Viewmodels
{
    public class CreateGroupViewModel : INotifyPropertyChanged
    {
        public string Name { get; set; }

        public string Section { get; set; }

        public bool IsIntroGroup { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
