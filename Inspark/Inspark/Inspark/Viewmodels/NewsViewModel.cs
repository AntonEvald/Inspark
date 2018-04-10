using Inspark.Models;
using Inspark.Views;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Inspark.Services;
using System.Linq;

namespace Inspark.Viewmodels
{
    public class NewsViewModel : BaseViewModel
    {
        public ApiServices api = new ApiServices();

        private ObservableCollection<NewsPost> newsPosts;

        public ObservableCollection<NewsPost> NewsPosts
        {

            get { return newsPosts; }
            set
            {
                if(newsPosts != value)
                {
                    newsPosts = value;
                    OnPropertyChanged();
                }

            }
        }

        private bool isRefreshing = false;

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }

        private NewsPost itemSelected;

        public NewsPost ItemSelected
        {
            get { return itemSelected; }
            set
            {
                if(itemSelected != value)
                {
                    itemSelected = value;
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
                if(_isVisible != value)
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
            var posts = await api.GetAllNewsPosts();
            posts = new ObservableCollection<NewsPost>(posts.OrderByDescending(i => i.Date));
            if(posts.Count < 1)
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

        public NewsViewModel()
        {
            IsRefreshing = true;
            RefreshListView();
            IsRefreshing = false;
        }
    }
}
