using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Inspark
{
    public partial class RegisterUserDetailsPage : ContentPage
    {
        public RegisterUserDetailsPage()
        {
            InitializeComponent();
        }

        public async void RegisterContinueEmail(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterConfirmEmailPage());
        }
    }
}
