using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Input;
using Inspark.Helpers;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    class ProfilePictureViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string imagePath;

        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                if (imagePath != value)
                {
                    imagePath = value;
                    OnPropertyChanged("Imagepath");
                }
                
            }
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public ICommand PickPhotoCommand => new Command(async () =>
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
            {
                return;
            }

            ImagePath = file.Path;
            var bild = File.ReadAllBytes(ImagePath);
            //Sätt användarens bild till variabeln bild här när det finns en funktion för att hämta ut nuvarande användare.
        });

        public ICommand LogOutCommand
        {
            get
            {
                return new Command(() =>
                    {
                        Settings.AccessToken = "";
                        Settings.UserName = "";
                        Settings.UserPassword = "";
                        Settings.KeepLoggedIn = false;
                    });
            }
        }

    }
}
