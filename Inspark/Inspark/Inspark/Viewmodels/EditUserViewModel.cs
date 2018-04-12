using Inspark.Models;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Inspark.Services;
using Inspark.Helpers;

namespace Inspark.Viewmodels
{
    public class EditUserViewModel : BaseViewModel
    {
        // This class is used for the edit user function. 
        private ApiServices _api = new ApiServices();

        public string ImagePath { get; set; }

        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged();
                }
            }
        }

        public byte[] NewPic { get; set; }

        private string _newPhoneNumber;

        public string NewPhoneNumber
        {
            get { return _newPhoneNumber; }
            set
            {
                if (_newPhoneNumber != value)
                {
                    _newPhoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                if(IsLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged();
                } 
            }
        }

        private string _currentPassword;

        public string CurrentPassword
        {
            get { return _currentPassword; }
            set
            {
                if(_currentPassword != value)
                {
                    _currentPassword = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand PickPhotoCommand => new Command(async () =>
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                Message = "Att välja bild stöds inte på denna enhet.";
            }
            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
            {
                return;
            }
            ImagePath = file.Path;
            NewPic = File.ReadAllBytes(ImagePath);
        });

        public ICommand ConfirmCommand => new Command(async() =>
        {
            IsLoading = true;
            var user = await _api.GetLoggedInUser();
            if(CurrentPassword == Settings.UserPassword)
            {
                if(NewPhoneNumber != null && NewPhoneNumber != "")
                {
                    if (NumberBehavior.IsNumbers(NewPhoneNumber))
                    {
                        user.PhoneNumber = NewPhoneNumber;
                    }
                    else
                    {
                        Message = "Ange ett telefonnummer med 10 siffror.";
                    }
                }
                if(NewPic != null)
                {
                    user.ProfilePicture = NewPic;
                }

                var isSuccess = await _api.EditUser(user);
                if (isSuccess)
                {
                    Message = "Ändringarna sparade!";
                    IsLoading = false;
                }
                else
                {
                    Message = "Något gick fel :(";
                    IsLoading = false;
                }
            }
            else
            {
                Message = "Fel lösenord!";
                IsLoading = false;
            }
        });
    }
}
