using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Inspark
{
    public partial class RegisterUserDetails : ContentPage
    {
        public RegisterUserDetails()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConfirmEmail());
        }
    }
}
