using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Inspark
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        public async void RegisterContinue_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterUserDetailsPage());
        }
    }
}
