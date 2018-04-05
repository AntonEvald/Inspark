using System;
using System.Collections.Generic;
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
        private readonly ApiServices _api = new ApiServices();

        private ObservableCollection<Group> groupList;
        public ObservableCollection<Group> GroupList
        {
            get { return groupList; }
            set
            {
                if (Equals(value, groupList)) return;
                groupList = value;
                OnPropertyChanged(nameof(GroupList));
            }
        }

        private ObservableCollection<User> userList;
        public ObservableCollection<User> UserList
        {
            get { return userList; }
            set
            {
                if (Equals(value, userList)) return;
                userList = value;
                OnPropertyChanged(nameof(UserList));
            }
        }

        private bool isLoading;

        public AddUserToGroupViewModel()
        {

            LoadCommand.Execute(null);
            var a = groupList;
        }

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


        public Command LoadCommand
        {
            get
            {
                return new Command(async (obj) =>
                {
                    var result = await _api.GetAllUsers();
                    UserList = new ObservableCollection<User>(result);
                    var result2 = await _api.GetAllGroups();
                    GroupList = result2;
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}