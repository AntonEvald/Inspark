using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Input;
using Inspark.Models;
using Inspark.Services;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    public class AddUserToGroupViewModel : BaseViewModel
    {
        ApiServices _api = new ApiServices();


        private Group _selectedGroup;

        public Group SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                if (_selectedGroup != value)
                {
                    _selectedGroup = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<Group> _groups;

        public ObservableCollection<Group> Groups
        {
            get { return _groups; }
            set
            {
                if(_groups != value)
                {
                    _groups = value;
                    OnPropertyChanged();
                }
            }
        }

        private User _selectedUsers;

        public User SelectedUser
        {
            get { return _selectedUsers; }
            set
            {
                if (_selectedUsers != value)
                {
                    _selectedUsers = value;
                    OnPropertyChanged();
                }

            }
        }
        
        private ObservableCollection<User> _users;

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                if(_users != value)
                {
                    _users = value;
                    OnPropertyChanged();
                }

            }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged();
                }

            }
        }

        public async void PopulateLists()
        {
            var users = await _api.GetAllUsers();
            users = new ObservableCollection<User>(users);
            Users = users;
            var groups = await _api.GetAllGroups();
            groups = new ObservableCollection<Group>(groups);
            Groups = groups;
        }

        public AddUserToGroupViewModel()
        {
            PopulateLists();
        }

        public ICommand AddUserToGroup => new Command(async () =>
        {
            var userId = SelectedUser.Id;
            var gruppId = SelectedGroup.Id;
            var isSuccess = await _api.AddUserToGroup(gruppId, userId);
            if (isSuccess)
            {
                Message = "Användaren har lagts till";
            }
            else
            {
                Message = "Något Gick Fel";
            }
        });
    
    }
}