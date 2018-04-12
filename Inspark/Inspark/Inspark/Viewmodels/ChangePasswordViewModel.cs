using Inspark.Helpers;
using Inspark.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    class ChangePasswordViewModel : BaseViewModel
    {
        private ApiServices _api = new ApiServices();

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

        private string _newPassword;

        public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                if (_newPassword != value)
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
                if (_confirmNewPassword != value)
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
                if (IsLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _oldPassword;

        public string OldPassword
        {
            get { return _oldPassword; }
            set
            {
                if(_oldPassword != value)
                {
                    _oldPassword = value;
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
                if (_currentPassword != value)
                {
                    _currentPassword = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ConfirmCommand => new Command(async () =>
        {
            IsLoading = true;
            if(NewPassword != "" && NewPassword != null && ConfirmNewPassword != "" && ConfirmNewPassword != null)
            {
                if (PasswordBehavior.IsValidPassword(NewPassword))
                {
                    if(PasswordBehavior.IsPasswordMatch(NewPassword, ConfirmNewPassword))
                    {
                        if(await _api.ChangePassword(NewPassword, OldPassword, ConfirmNewPassword, Settings.AccessToken))
                        {
                            Message = "";
                            IsLoading = false;
                        }
                        else
                        {
                            Message = "Inte implementerat än";
                        }
                    }
                    else
                    {
                        Message = "Dina nya lösenord stämmer inte överens.";
                        IsLoading = false;
                    }
                }
                else
                {
                    Message = "Ditt lösenord måste innehålla en siffra, en versal, en gemen och bestå av minst 6 tecken";
                    IsLoading = false;
                }
            }
            else
            {
                Message = "Ange ett nytt lösenord och bekräfta det.";
                IsLoading = false;
            }
        });
    }
}
