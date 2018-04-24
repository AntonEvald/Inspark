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

        private string _imagePath;

        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                if(_imagePath != value)
                {
                    _imagePath = value;
                    OnPropertyChanged();
                }
            }
        }

        private User _user;

        public User User
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged();
                }
            }
        }


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


        private byte[] _pic;

        public byte[] Pic
        {
            get { return _pic; }
            set
            {
                if (_pic != value)
                {
                    _pic = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _phoneNumber;

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }


        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
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
            Pic = File.ReadAllBytes(ImagePath);
        });

        public ICommand RemovePicCommand => new Command(() =>
        {
            ImagePath = "";
            Pic = null;
            IsVisible = false;
        });

        public ICommand ConfirmCommand => new Command(async() =>
        {
            IsLoading = true;
            var model = new EditUserModel();
            model.Id = User.Id;
            if(CurrentPassword == Settings.UserPassword)
            {
                if(PhoneNumber != null && PhoneNumber != "")
                {
                    if (NumberBehavior.IsNumbers(PhoneNumber))
                    {
                        model.PhoneNumber = PhoneNumber;
                    }
                    else
                    {
                        Message = "Ange ett telefonnummer med 10 siffror.";
                    }
                }
                model.ProfilePicture = Pic;
                model.FirstName = User.FirstName;
                model.LastName = User.LastName;
                var isSuccess = await _api.EditUser(model);
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

        public async void OnLoad()
        {
            IsLoading = true;
            User = await _api.GetLoggedInUser();
            Pic = User.ProfilePicture;
            PhoneNumber = User.PhoneNumber;
            if(Pic != null)
            {
                IsVisible = true;
            }
            IsLoading = false;

        }

        public EditUserViewModel()
        {
            OnLoad();
        }
    }
}
