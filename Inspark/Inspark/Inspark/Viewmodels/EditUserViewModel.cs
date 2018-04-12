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

        private User _user;

        public User User
        {
            get { return _user; }
            set {
                if(_user != value)
                {
                    _user = value;
                    OnPropertyChanged();
                }
            }
        }

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

        private string _newPassword;

        public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                if(_newPassword != value)
                {
                    _newPassword = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _confirmNewPassword;

        public string ConfirmNewPassword
        {
            get { return _confirmNewPassword; }
            set
            {
                if(_confirmNewPassword != value)
                {
                    _confirmNewPassword = value;
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
            User = await _api.GetLoggedInUser();
            if(CurrentPassword == Settings.UserPassword)
            {
                if(NewPassword != null && NewPassword != "")
                {
                    if (PasswordBehavior.IsValidPassword(NewPassword))
                    {
                        if (NewPassword == ConfirmNewPassword)
                        {
                            User.ConfirmPassword = ConfirmNewPassword;
                            User.Password = NewPassword;
                        }
                        else
                        {
                            Message = "Ditt nya lösenord och det bekräftade lösenordet stämmer inte överens";
                            IsLoading = false;
                        }
                    }
                    else
                    {
                        Message = "Ditt nya lösenord måste vara minst 6 tecken långt och innehålla minst en siffra, en versal och gemen.";
                        IsLoading = false;
                    }

                }
                if(NewPhoneNumber != null && NewPhoneNumber != "")
                {
                    if (NumberBehavior.IsNumbers(NewPhoneNumber))
                    {
                        User.PhoneNumber = NewPhoneNumber;
                    }
                    else
                    {
                        Message = "Ange ett telefonnummer med 10 siffror.";
                    }
                }
                if(NewPic != null)
                {
                    User.ProfilePicture = NewPic;
                }

                var isSuccess = await _api.EditUser(User);
                if (isSuccess)
                {
                    Message = "Ändringarna sparade!";
                    Settings.UserPassword = NewPassword;
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
