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

namespace Inspark.Viewmodels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {

        Services.ApiServices apiServices = new Services.ApiServices();

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public byte[] Pic { get; set; }

        private string imagePath;
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

        public bool IsLoggedIn { get; set; }

        private string section;

        public string Section
        {
            get { return section; }
            set
            {
                if(section != value)
                {
                    section = value;
                    OnPropertyChanged("Section");
                }
            }
                
        }


        private string message;

        public event PropertyChangedEventHandler PropertyChanged;

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

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public ICommand PickPhotoCommand => new Command(async () =>
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
            
             
        });
        public ICommand RegisterCommand => new Command(async () =>
        {
            if(TextOnlyBehavior.IsTextOnly(FirstName) && TextOnlyBehavior.IsTextOnly(LastName) && EmailBehaviors.IsEmail(Email) && NumberBehavior.IsNumbers(PhoneNumber) && PasswordBehavior.IsValidPassword(Password) && PasswordBehavior.IsPasswordMatch(Password, ConfirmPassword))
            {
                if(Section != null && Section != "")
                {
                    Pic = File.ReadAllBytes(ImagePath);
                    var isSuccess = await apiServices.RegisterAsync(FirstName, LastName, Email, Password, section, PhoneNumber, Pic, true);

                    if (isSuccess)
                    {
                        Message = "Ja!";
                        var page = new Views.MainPage();
                        NavigationPage.SetHasNavigationBar(page, false);
                        await Application.Current.MainPage.Navigation.PushAsync(page);
                    }
                    else
                    {
                        Message = "Försök igen!";
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
