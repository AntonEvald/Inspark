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

        public async void populateList()
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
            populateList();
        }

        public ICommand AddUserToGroup => new Command( () =>
        {
            var a = SelectedUser;
            var b = SelectedUser;

        });
    
    }
}