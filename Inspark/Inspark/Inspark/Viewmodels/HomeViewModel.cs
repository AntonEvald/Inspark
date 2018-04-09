﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Inspark.Models;
using Inspark.Services;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    class HomeViewModel : INotifyPropertyChanged
    {
        private ApiServices api = new ApiServices();
        
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

        private bool _isRefreshing;

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                if(_isRefreshing != value)
                {
                    _isRefreshing = value;
                    OnPropertyChanged("IsRefreshing");
                }
            }
        }


        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsRefreshing = true;

                    RefreshNewsListView();

                    IsRefreshing = false;
                });
            }
        }

        private async void RefreshNewsListView()
        {
            NewsPosts = await api.GetAllNewsPosts();
            if (NewsPosts.Count == 0)
            {
                var post = new NewsPost()
                {
                    Author = "Admin",
                    Text = "Det finns inga poster ännu.",
                    Title = "Det finns inga poster ännu.",
                    DateTime = DateTime.Now,
                    Picture = null
                };
                NewsPosts.Add(post);
            }
        }

        public HomeViewModel()
        {
            RefreshNewsListView();

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
