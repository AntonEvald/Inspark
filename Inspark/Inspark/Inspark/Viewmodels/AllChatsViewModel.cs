using Inspark.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ObservableCollection<Chat> _chats;

        public ObservableCollection<Chat> Chats
        {
            get { return Chats; }
            set { Chats = value; OnPropertyChanged(); }
        }



    }
}
