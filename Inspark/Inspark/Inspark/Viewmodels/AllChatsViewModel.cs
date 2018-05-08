using Inspark.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Inspark.Viewmodels
{
    public class AllChatsViewModel : BaseViewModel
    {
        private string _keyword;

        public string Keyword
        {
            get { return _keyword; }
            set { _keyword = value; OnPropertyChanged(); }
        }

        private bool _isVisible;

        public bool IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; OnPropertyChanged(); }
        }

        private ObservableCollection<User> _allUsers;

        public ObservableCollection<User> AllUsers
        {
            get { return _allUsers; }
            set { _allUsers = value; OnPropertyChanged(); }
        }

        private ObservableRangeCollection<Group> _userGroups;

        public ObservableRangeCollection<Group> UserGroups
        {
            get { return _userGroups; }
            set { _userGroups = value; OnPropertyChanged(); }
        }



        private ObservableRangeCollection<Chat> _chats;

        public ObservableRangeCollection<Chat> Chats
        {
            get { return _chats; }
            set { _chats = value; OnPropertyChanged(); }
        }

        public User User { get; set; }

        public AllChatsViewModel()
        {
            OnLoad();
        }

        async void OnLoad()
        {
            User = await _api.GetLoggedInUser();
            AllUsers = await _api.GetAllUsers();
            var allGroups = await _api.GetAllGroups();
            var userGroups = allGroups.Where(x => x.Users.Contains(User));
        }

    }
}
