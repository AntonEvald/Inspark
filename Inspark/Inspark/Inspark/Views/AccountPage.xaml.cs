using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inspark.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AccountPage : ContentPage
	{
		public AccountPage ()
		{
			InitializeComponent ();
		}

	    public void ShowProfileButton_Clicked(object sender, EventArgs e)
	    {
	        var page = new ProfilePage();
	        InsparkAccount.Content = page.Content;
	    }

        public void ChangeUserDetailsButton_Clicked(object sender, EventArgs e)
        {
            var page = new ChangeUserDetailsPage();
            InsparkAccount.Content = page.Content;
        }

		private async void LogOut_Clicked(object sender, EventArgs e)
		{
			Application.Current.MainPage = new NavigationPage(new FrontPage());
		}
	}
}