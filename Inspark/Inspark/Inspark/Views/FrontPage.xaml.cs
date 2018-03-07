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

        public async void Login_Clicked(EventArgs e)
        {
            await Navigation.PushAsync(new Views.LoginPage());
        }
    }
}
