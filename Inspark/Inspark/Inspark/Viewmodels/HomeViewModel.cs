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
                    RefreshNewsListView();
                });
            }
        }

        private async void RefreshNewsListView()
        {
            IsRefreshing = true;
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
            IsRefreshing = false;
        }

        private async void RefreshGroupListView()
        {
            IsRefreshing = true;
            var posts = await _api.GetAllGroupPosts();
            posts = new ObservableCollection<GroupPost>(posts.OrderByDescending(i => i.Date));
            if (posts.Count < 1)
            {
                var post = new GroupPost()
                {
                    Author = "Admin",
                    Text = "Det finns inga poster ännu.",
                    Title = "Det finns inga poster ännu.",
                    Date = DateTime.Now,
                    Picture = null
                };
                posts.Add(post);
            }
            GroupPosts = posts;
            IsRefreshing = false;
        }

        public HomeViewModel()
        {
            RefreshNewsListView();
            RefreshGroupListView();
        }
    }
}
