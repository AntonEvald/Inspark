using Inspark.Models;
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

        private ObservableRangeCollection<GroupChatDisplayModel> _groupChatDisplayModels;

        public ObservableRangeCollection<GroupChatDisplayModel> GroupChatDisplayModels
        {
            get { return _groupChatDisplayModels; }
            set { _groupChatDisplayModels = value; OnPropertyChanged(); }
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
                if (suggestionListCollection.Where(x => x.Id == User.Id).Count() != 0)
                {
                    suggestionListCollection.Remove(suggestionListCollection.Where(x => x.Id == User.Id).First());
                }
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

        public void OpenChat(GroupChat chat)
        {
            Application.Current.MainPage = new MainPage(new ChatPage(chat));
        }

        public void OpenChat(GroupChatDisplayModel gcdm)
        {
            var chat = GroupChats.Where(x => x.Id == gcdm.Id).First();
            Application.Current.MainPage = new MainPage(new ChatPage(chat));
        }

        public async void CreateChat(User reciver)
        {
            bool foundExistingChat = false;
            if (Chats.Count != 0)
            {
                foreach (var chat in Chats)
                {
                    var chatMembers = chat.Users;
                    foreach (var member in chatMembers)
                    {
                        if (member.Id == reciver.Id)
                        {
                            OpenChat(chat);
                            foundExistingChat = true;
                            break;
                        }
                    }
                    if (foundExistingChat)
                    {
                        break;
                    }
                }
            }
            if (foundExistingChat == false)
            {
                if (await _api.CreatePrivateChat(User.Id, reciver.Id))
                {
                    OnLoad();
                    if (Chats.Count != 0)
                    {
                        foreach (var chat in Chats)
                        {
                            var chatMembers = chat.Users;
                            foreach (var member in chatMembers)
                            {
                                if (member.Id == reciver.Id)
                                {
                                    OpenChat(chat);
                                }
                            }
                        }
                    }
                }
            }
        }

        async void OnLoad()
        {
            ChatDisplayModels = new ObservableRangeCollection<ChatDisplayModel>();
            Chats = new ObservableRangeCollection<Chat>();
            GroupChats = new ObservableRangeCollection<GroupChat>();
            GroupChatDisplayModels = new ObservableRangeCollection<GroupChatDisplayModel>();
            User = await _api.GetLoggedInUser();
            AllUsers = await _api.GetAllUsers();
            if(User.Chats.Count != 0)
            {
                Chats.AddRange(User.Chats);
            }
            if(User.GroupChats.Count != 0)
            {
                GroupChats.AddRange(User.GroupChats);
            }
            if(GroupChats.Count != 0)
            {
                foreach(var gc in GroupChats)
                {
                    var gcdm = new GroupChatDisplayModel
                    {
                        Id = gc.Id,
                        ChatName = gc.GroupName,
                        ChatPic = gc.GroupChatPic,
                    };
                    if(gc.Messages.Count != 0)
                    {
                        gcdm.LatestMessage = gc.Messages.Last().Text;
                        gcdm.LatestMessageDate = gc.Messages.Last().MessageDateTime;
                    }
                    else
                    {
                        gcdm.LatestMessage = "Inga meddelanden skickade";
                    }
                    GroupChatDisplayModels.Add(gcdm);
                }
                GroupChatDisplayModels.OrderByDescending(x => x.LatestMessageDate);
            }
            if(Chats.Count != 0)
            {
                foreach (var c in Chats)
                {
                    var otherUser = c.Users.Where(x => x.Id != User.Id).First();
                    var chatView = new ChatDisplayModel
                    {
                        Id = c.Id,
                        DisplayName = otherUser.FirstName + " " + otherUser.LastName,
                        ChatPic = User.ProfilePicture,
                    };
                        
                    if (c.Messages.Count == 0)
                    {
                        chatView.LatestMessage = "Inga meddelanden skickade";
                    }
                    else
                    {
                        chatView.LatestMessage = c.Messages.Last().Text;
                        chatView.LatestMessageDate = c.Messages.Last().MessageDateTime;
                    }
                    ChatDisplayModels.Add(chatView);
                }
                ChatDisplayModels.OrderByDescending(x => x.LatestMessageDate);
            }
        }
    }
}
