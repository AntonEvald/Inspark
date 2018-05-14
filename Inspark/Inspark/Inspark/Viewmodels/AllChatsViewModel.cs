﻿using Inspark.Models;
using Inspark.Views;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

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

        private bool _isSearchListVisible;

        public bool IsSearchListVisible
        {
            get { return _isSearchListVisible; }
            set { _isSearchListVisible = value; OnPropertyChanged(); }
        }

        private ObservableRangeCollection<GroupChat> _groupChats;

        public ObservableRangeCollection<GroupChat> GroupChats
        {
            get { return _groupChats; }
            set { _groupChats = value; OnPropertyChanged(); }
        }


        private ObservableCollection<User> _allUsers;

        public ObservableCollection<User> AllUsers
        {
            get { return _allUsers; }
            set { _allUsers = value; OnPropertyChanged(); }
        }

        private ObservableRangeCollection<User> _suggestions;

        public ObservableRangeCollection<User> Suggestions
        {
            get { return _suggestions; }
            set { _suggestions = value; OnPropertyChanged(); }
        }


        private ObservableRangeCollection<Chat> _chats;

        public ObservableRangeCollection<Chat> Chats
        {
            get { return _chats; }
            set { _chats = value; OnPropertyChanged(); }
        }

        private ObservableRangeCollection<ChatDisplayModel> _chatDisplayModels;

        public ObservableRangeCollection<ChatDisplayModel> ChatDisplayModels
        {
            get { return _chatDisplayModels; }
            set { _chatDisplayModels = value; OnPropertyChanged(); }
        }


        public User User { get; set; }

        public ICommand SearchCommand
        {
            get { return new Command(Search); }
        }

        private void Search()
        {
            if (_keyword.Length >= 1)
            {
                var suggestionsList = AllUsers.Where(c => c.FirstName.ToLower().Contains
                 (_keyword.ToLower()) || c.LastName.ToLower().Contains(_keyword.ToLower()));

                var suggestionListCollection = new ObservableRangeCollection<User>(suggestionsList);
                Suggestions = suggestionListCollection;

                IsSearchListVisible = true;
            }
            else
            {
                IsSearchListVisible = false;
            }
        }

        public AllChatsViewModel()
        {
            OnLoad();
        }

        public void OpenChat(ChatDisplayModel cdm)
        {
            var chat = Chats.Where(x => x.Id == cdm.Id).First();
            if (Chats.Contains(chat))
            {
                Application.Current.MainPage = new MainPage(new ChatPage(chat));
            }
        }

        public void OpenChat(Chat chat)
        {
            Application.Current.MainPage = new MainPage(new ChatPage(chat));
        }

        public async void CreateChat(User reciver)
        {
            var users = new List<User>
            {
                User,
                reciver
            };
            var chat = new Chat
            {
                Messages = new ObservableCollection<Message>(),
                Users = users,
            };
            if (Chats.Where(x => x.Users == chat.Users).Count() != 0)
            {
                OpenChat(chat);
            }
            else
            {
                Chats.Add(chat);
                OpenChat(chat);
                await _api.CreateChat(chat);
            }
        }

        async void OnLoad()
        {
            ChatDisplayModels = new ObservableRangeCollection<ChatDisplayModel>();
            Chats = new ObservableRangeCollection<Chat>();
            User = await _api.GetLoggedInUser();
            AllUsers = await _api.GetAllUsers();
            Chats.AddRange(User.Chats);

            foreach(var c in Chats)
            {
                var otherUser = c.Users.Where(x => x.Id != User.Id).First();
                var chatView = new ChatDisplayModel
                {
                    Id = c.Id,
                    DisplayName = otherUser.FirstName + " " + otherUser.LastName,
                    ChatPic = User.ProfilePicture,
                    LatestMessage = c.Messages.Last().Text,
                    LatestMessageDate = c.Messages.Last().MessageDateTime
                };
                ChatDisplayModels.Add(chatView);
            }
            ChatDisplayModels.OrderByDescending(x => x.LatestMessageDate);
        }
    }
}
