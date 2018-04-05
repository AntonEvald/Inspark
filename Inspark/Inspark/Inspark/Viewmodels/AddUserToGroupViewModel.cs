using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Windows.Input;
using Inspark.Models;
using Inspark.Services;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    public class AddUserToGroupViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<User> UserList { get; set; }
        public ObservableCollection<Group> GroupList { get; set; }
        private readonly ApiServices _api = new ApiServices();

        private bool isLoading;

        public bool IsLoading
        {
            get { return isLoading; }
            set
            {
                if (isLoading != value)
                {
                    isLoading = value;
                    OnPropertyChanged("IsLoading");
                }
            }
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public AddUserToGroupViewModel()
        {
            loadDate();
            var a = UserList.Count();
        }

        private async void loadDate()
        {
            var result = await _api.GetAllUsers();
            UserList =  new ObservableCollection<User>(result);
            var result2 = await _api.GetAllGroups();
            GroupList = new ObservableCollection<Group>(result2);
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}