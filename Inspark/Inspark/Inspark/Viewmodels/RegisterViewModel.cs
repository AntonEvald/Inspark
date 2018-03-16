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


        public ICommand RegisterCommand => new Command(async () =>
        {
            if(TextOnlyBehavior.IsTextOnly(FirstName) && TextOnlyBehavior.IsTextOnly(LastName) && EmailBehaviors.IsEmail(Email) && NumberBehavior.IsNumbers(PhoneNumber) && PasswordBehavior.IsValidPassword(Password) && PasswordBehavior.IsPasswordMatch(Password, ConfirmPassword))
            {
                if(Section != null && Section != "")
                {
                var isSuccess = await apiServices.RegisterAsync(FirstName, LastName, Email, Password, section, PhoneNumber, Pic, true);

                    if (isSuccess)
                    {
                        Message = "Ja!";
                        await Application.Current.MainPage.Navigation.PushAsync(new Views.MainPage());
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
