﻿using Inspark.Models;
using Inspark.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    class GroupPostsViewModel : BaseViewModel
    {
        private ApiServices _api = new ApiServices();

        private ObservableCollection<GroupPost> _groupPosts;

        public ObservableCollection<GroupPost> GroupPosts
        {
            get { return _groupPosts; }
            set
            {
                if(_groupPosts != value)
                {
                    _groupPosts = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isRefreshing = false;

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

        private NewsPost _itemSelected;

        public NewsPost ItemSelected
        {
            get { return _itemSelected; }
            set
            {
                if (_itemSelected != value)
                {
                    _itemSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isVisible;

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                if (_isVisible != value)
                {
                    _isVisible = value;
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

                    RefreshListView();

                    IsRefreshing = false;
                });
            }
        }

        private async void RefreshListView()
        {
            var posts = await _api.GetAllGroupPosts();
            posts = new ObservableCollection<GroupPost>(posts.OrderByDescending(i => i.Date));
            if (posts.Count < 1)
            {
                var post = new GroupPost()
                {
                    Author = "Admin",
                    Text = "Det finns inga poster ännu.",
                    Title = "Det finns inga poster ännu.",
                    Description = "Det finns inga poster ännu",
                    Date = DateTime.Now,
                    Picture = null
                };
                posts.Add(post);
                posts.Add(post);
                posts.Add(post);
            }
            GroupPosts = posts;
        }

        public GroupPostsViewModel()
        {
            IsRefreshing = true;
            RefreshListView();
            IsRefreshing = false;
        }

    }
}
