using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Inspark.Models;
using Inspark.Services;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    class HomeViewModel : BaseViewModel
    {
        private ApiServices _api = new ApiServices();
        
        private ObservableCollection<GroupPost> _groupPosts;

        public ObservableCollection<GroupPost> GroupPosts
        {
            get { return  _groupPosts; }
            set
            {
                if(_groupPosts != value)
                {
                    _groupPosts = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<NewsPost> _newsPosts;

        public ObservableCollection<NewsPost> NewsPosts
        {
            get { return _newsPosts; }
            set
            {
                if(_newsPosts != value)
                {
                    _newsPosts = value;
                    OnPropertyChanged();
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
                    OnPropertyChanged();
                }
            }
        }

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
            var posts = await _api.GetAllNewsPosts();
            posts = new ObservableCollection<NewsPost>(posts.OrderByDescending(i => i.Date));
            if (posts.Count < 1)
            {
                var post = new NewsPost()
                {
                    Author = "Admin",
                    Text = "Det finns inga poster ännu.",
                    Title = "Det finns inga poster ännu.",
                    Date = DateTime.Now,
                    Picture = null
                };
                posts.Add(post);
            }
            NewsPosts = posts;
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
