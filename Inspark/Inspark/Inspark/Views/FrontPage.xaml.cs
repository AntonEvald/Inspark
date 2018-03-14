using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Inspark
{
    public partial class FrontPage : ContentPage
    {
        public FrontPage()
        {
            InitializeComponent();
        }

        public async void Login_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.LoginPage());
        }

        public async void Register_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        public async void MainPage_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Views.MainPage());
        }
    }
}
