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

namespace Inspark.Viewmodels
{
    class NewsViewModel : INotifyPropertyChanged
    {
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

        private string postTitle;

        public string PostTitle
        {
            get { return postTitle; }
            set
            {
                if(postTitle != value)
                {
                    postTitle = value;
                    OnPropertyChanged("PostTitle");
                }
                
            }
        }

        private string postText;

        public string PostText
        {
            get { return postText; }
            set
            {
                if(postText != value)
                {
                    postText = value;
                    OnPropertyChanged("PostText");
                }
                
            }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set
            {
                if(message != value)
                {
                    message = value;
                    OnPropertyChanged("Message");
                }
            }
        }

        public string imagePath;

        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                if(imagePath != value)
                {
                    imagePath = value;
                    OnPropertyChanged("ImagePath");
                }
            }
        }

        private byte[] postImage;

        public byte[] PostImage
        {
            get { return postImage; }
            set
            {
                if(postImage != value)
                {
                    postImage = value;
                    OnPropertyChanged("PostImage");
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
                OnPropertyChanged("IsRefreshing");
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
                    OnPropertyChanged("ItemSelected");
                }
            }
        }

        public ICommand ItemTappedCommand => new Command(() =>
        {
            NewsPost post = ItemSelected;
            new NavigationPage(new MainPage(new PostPage(post)));
        });

        public ICommand AddPicCommand => new Command(async () =>
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                Message = "Att välja bild stöds inte på denna enhet";
            }
            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
            {
                return;
            }
            ImagePath = file.Path;
            PostImage = File.ReadAllBytes(ImagePath);
            
        });

        public ICommand PostCommand => new Command(() =>
        {
            var post = new NewsPost()
            {
                Title = postTitle,
                Text = postText,
                Picture = PostImage
            };
            NewsPosts.Add(post);
            
        });


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

        private void RefreshListView()
        {
            NewsPosts = newsPosts;
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public NewsViewModel()
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
        }
    }
}
