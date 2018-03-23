using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Inspark.Models;

namespace Inspark.Viewmodels
{
    class HomeViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<GroupPost> groupPosts;

        public ObservableCollection<GroupPost> GroupPosts
        {
            get { return  groupPosts; }
            set
            {
                if(groupPosts != value)
                {
                    groupPosts = value;
                    OnPropertyChanged("GroupPosts");
                }
            }
        }

        private ObservableCollection<NewsPost> newsPosts;

        public ObservableCollection<NewsPost> NewsPosts
        {
            get { return newsPosts; }
            set
            {
                if(newsPosts != value)
                {
                    newsPosts = value;
                    OnPropertyChanged("NewsPosts");
                }
            }
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public HomeViewModel()
        {
            NewsPosts = new ObservableCollection<NewsPost>()
            {
                new NewsPost() { Id = 1, Description = "Info", Text = "Ja", Title = "Titel" },
                new NewsPost() { Id = 2, Description = "Info", Text = "Ja", Title = "Titel" },
                new NewsPost() { Id = 3, Description = "Info", Text = "Ja", Title = "Titel" },
                new NewsPost() { Id = 4, Description = "Info", Text = "Ja", Title = "Titel" },
                new NewsPost() { Id = 5, Description = "Info", Text = "Ja", Title = "Titel" },
                new NewsPost() { Id = 6, Description = "Info", Text = "Ja", Title = "Titel" }
            };

            GroupPosts = new ObservableCollection<GroupPost>()
            {
                new GroupPost() { Id = 1, Description = "Info", Text = "Ja", Title = "Titel" },
                new GroupPost() { Id = 2, Description = "Info", Text = "Ja", Title = "Titel" },
                new GroupPost() { Id = 3, Description = "Info", Text = "Ja", Title = "Titel" },
                new GroupPost() { Id = 4, Description = "Info", Text = "Ja", Title = "Titel" },
                new GroupPost() { Id = 5, Description = "Info", Text = "Ja", Title = "Titel" },
                new GroupPost() { Id = 6, Description = "Info", Text = "Ja", Title = "Titel" }
            };
        }
    }
}
