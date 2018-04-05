using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inspark.Helpers;
using Inspark.Viewmodels;
using Inspark.Views;
using Xamarin.Forms;

namespace Inspark
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            if (DateTime.UtcNow.AddHours(1) > Settings.AccessTokenExpires)
            {
                var vm = new LoginViewModel();
                vm.LoginClick.Execute(null);
            }
            var a = Settings.UserPassword;
            if (Settings.UserPassword == "")
            {
                MainPage = new NavigationPage(new FrontPage());
            }
            else
            {
                MainPage = new MainPage();
            }

		}


		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
