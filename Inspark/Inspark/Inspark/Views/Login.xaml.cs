using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Inspark
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            Title = "Logga in";
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            //kolla lösenord och skit
            Navigation.PushModalAsync(new MainPage());
        }
    }
}
