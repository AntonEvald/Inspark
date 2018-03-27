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

	    private void ShowProfileButton_Clicked(object sender, EventArgs e)
	    {
	        var page = new ProfilePage();
	        InsparkAccount.Content = page.Content;
	    }

        public void ChangeUserDetailsButton_Clicked(object sender, EventArgs e)
        {
            var page = new ChangeUserDetailsPage();
            InsparkAccount.Content = page.Content;
        }

        public void ChangeProfilePictureButton_Clicked(object sender, EventArgs e)
        {
            var page = new ChangeProfilePicture();
            InsparkAccount.Content = page.Content;
        }

        public void LogOutButton_Clicked(object sender, EventArgs e)
        {
            // Kod som loggar ut personen. 
        }


	}
}