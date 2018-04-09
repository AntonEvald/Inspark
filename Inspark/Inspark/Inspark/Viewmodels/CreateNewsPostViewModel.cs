using Inspark.Models;
using Inspark.Services;
using Inspark.Views;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    public class CreateNewsPostViewModel : INotifyPropertyChanged
    {

        private ApiServices api = new ApiServices();

        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                if(_message != value)
                {
                    _message = value;
                    OnPropertyChanged("Message");
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
                    OnPropertyChanged("IsVisible");
                }
            }
        }
        private byte[] postImage;

        public byte[] PostImage
        {
            get { return postImage; }
            set
            {
                if (postImage != value)
                {
                    postImage = value;
                    OnPropertyChanged("PostImage");
                }

            }
        }


        public string imagePath;

        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                if (imagePath != value)
                {
                    imagePath = value;
                    OnPropertyChanged("ImagePath");
                }
            }
        }

        private string postTitle;

        public string PostTitle
        {
            get { return postTitle; }
            set
            {
                if (postTitle != value)
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
                if (postText != value)
                {
                    postText = value;
                    OnPropertyChanged("PostText");
                }

            }
        }

        public ICommand PostCommand => new Command(async () =>
        {
            var user = await api.GetLoggedInUser();
            if(postTitle != null && postTitle != "" && PostText != null && postText != "")
            {
                var post = new NewsPost()
                {
                    Title = postTitle,
                    Text = postText,
                    Picture = PostImage,
                    Author = user.FirstName + " " + user.LastName,
                    SenderId = user.Id,
                    Date = DateTime.Now,
                };
                if (await api.CreatePost(post))
                {
                    Message = "En post har skapats!";
                    var page = new MainPage(new HomePage());
                    NavigationPage.SetHasNavigationBar(page, false);
                    await Application.Current.MainPage.Navigation.PushAsync(page);
                }
                else
                {
                    Message = "Något gick fel";
                }
            }
            else
            {
                Message = "Ange en titel och en text för din post!";
            }


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
            IsVisible = true;
        });


        public ICommand RemovePicCommand => new Command(() =>
        {
            ImagePath = "";
            PostImage = null;
            IsVisible = false;
        });

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
