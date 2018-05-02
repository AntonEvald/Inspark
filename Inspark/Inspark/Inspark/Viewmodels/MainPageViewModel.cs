using Inspark.Models;
using Inspark.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Inspark.Viewmodels
{
    class MainPageViewModel : BaseViewModel
    {
        private ApiServices _api = new ApiServices();

        public User User { get; set; }

        private byte[] _profilePicture;

        public byte[] ProfilePicture
        {
            get { return _profilePicture; }
            set
            {
                _profilePicture = value;
                OnPropertyChanged();
            }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }


        private bool _isAdmin;

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                _isAdmin = value;
                OnPropertyChanged();
            }
        }

        public string Role { get; set; }

        private bool _isIntro;

        public bool IsIntro
        {
            get { return _isIntro; }
            set
            {
                _isIntro = value;
                OnPropertyChanged();
            }
        }



        public async void OnLoad()
        {
            User = await _api.GetLoggedInUser();
            if(User.ProfilePicture != null)
            {
                ProfilePicture = User.ProfilePicture;
            }
            else
            {
                var assembly = Assembly.GetExecutingAssembly();
                var pic = EmbeddedResourceToByteArray.GetEmbeddedResourceBytes(assembly, "profile.png");
                ProfilePicture = pic;
            }
            FirstName = User.FirstName;
            if(User.Role == "Admin")
            {
                IsAdmin = true;
                IsIntro = true;
            }
            else
            {
                IsAdmin = false;
                if(User.Role == "Fadder" || User.Role == "Intro")
                {
                    IsIntro = true;
                }
                else
                {
                    IsIntro = false;
                }
            }
        }

        public MainPageViewModel()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var pic = EmbeddedResourceToByteArray.GetEmbeddedResourceBytes(assembly, "profile.png");
            ProfilePicture = pic;
            FirstName = "No user";
            //OnLoad();
        }

    }
}
