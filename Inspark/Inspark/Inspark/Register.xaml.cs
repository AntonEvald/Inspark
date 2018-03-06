using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Inspark
{
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
            Title = "Registrera";
        }

        private async void UserInformationButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterUserDetails());
        }
    }
}
