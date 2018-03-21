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
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
		}

        public void NewsTapped(object sender, EventArgs e)
        {
            var page = new NewsPage();
            HomePageContent.Content = page.Content;
        }

        public void GroupTapped(object sender, EventArgs e)
        {
            var page = new MainPage(new GroupPage());
            Navigation.PushAsync(page);
        }
    }
}