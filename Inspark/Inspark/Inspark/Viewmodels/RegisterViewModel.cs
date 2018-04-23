using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Inspark.Services;
using Plugin.Media;
using System.IO;
using Inspark.Helpers;
using Inspark.Models;
using System.Collections.ObjectModel;

namespace Inspark.Viewmodels
{
    public class RegisterViewModel : BaseViewModel
    {
        // This class is used for the register user function. 
        private ApiServices _api = new ApiServices();

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public byte[] Pic { get; set; }

        private string _imagePath;

        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                if (_imagePath != value)
                {
                    _imagePath = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<Section> _sectionList;

        public ObservableCollection<Section> SectionsList
        {
            get { return _sectionList; }
            set
            {
                if (_sectionList != value)
                {
                    _sectionList = value;
                    OnPropertyChanged();
                }
            }
        }

        public RegisterViewModel()
        {
            SectionsList = new ObservableCollection<Section>()
            {
                new Section() {Id = 1, Name = "Handelshögskolan"},
                new Section() {Id = 2, Name = "Humaniora, utbildnings- och samhällsvetenskap"},
                new Section() {Id = 3, Name = "Hälsovetenskaper"},
                new Section() {Id = 4, Name = "Juridik, psykologi och socialt arbete"},
                new Section() {Id = 5, Name = "Medicinska vetenskaper"},
                new Section() {Id = 6, Name = "Musikhögskolan"},
                new Section() {Id = 7, Name = "Naturvetenskap och teknik"},
                new Section() {Id = 8, Name = "Restaurang- och hotellhögskolan"}
            };

            IsVisible = false;
            ImagePath = "";
        }

        public bool IsLoggedIn { get; set; }

        private Section _section;

        public Section Section
        {
            get { return _section; }
            set
            {
                if(_section != value)
                {
                    _section = value;
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

        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                if(_message != value)
                {
                    _message = value;
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
                if(_isLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddPicCommand => new Command(async () =>
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                Message = "Att välja bild stöds inte på denna enhet.";
            }
            var file = await CrossMedia.Current.PickPhotoAsync();
            if(file == null)
            {
                return;
            }
            ImagePath = file.Path;
            IsVisible = true;
        });

        public ICommand RemovePicCommand => new Command(() =>
        {
            ImagePath = "";
            Pic = null;
            IsVisible = false;
        });

        public ICommand RegisterCommand => new Command(async () =>
        {
            if(TextOnlyBehavior.IsTextOnly(FirstName) && TextOnlyBehavior.IsTextOnly(LastName) && EmailBehaviors.IsEmail(Email) && NumberBehavior.IsNumbers(PhoneNumber) && PasswordBehavior.IsValidPassword(Password) && PasswordBehavior.IsPasswordMatch(Password, ConfirmPassword))
            {
                if(Section != null)
                {
                    IsLoading = true;
                    Pic = File.ReadAllBytes(ImagePath);
                    ImageSource source = ImageSource.FromFile("profile.png");
                    var user = new User
                    {
                        UserName = Email,
                        Password = Password,
                        Email = Email,
                        Section = Section.Name,
                        FirstName = FirstName,
                        LastName = LastName,
                        Role = "Admin",
                        ConfirmPassword = Password,
                        PhoneNumber = PhoneNumber,
                        ProfilePicture = Pic,
                    };
                    var isSuccess = await _api.RegisterAsync(user);

                    if (isSuccess)
                    {
                        Settings.UserName = Email;
                        Settings.UserPassword = Password;
                        var page = new Views.MainPage(new Views.HomePage());
                        NavigationPage.SetHasNavigationBar(page, false);
                        await Application.Current.MainPage.Navigation.PushAsync(page);
                        IsLoading = false;
                    }
                    else
                    {
                        Message = "Försök igen!";
                        IsLoading = false;
                    }
                }
                else
                {
                    Message = "Välj den sektion du tillhör!";
                }
            }
            else
            {
                Message = "Ett eller flera inmatningsfält stämmer inte. Kontrollera dina uppgifter.";
            }
        });
    }
}
