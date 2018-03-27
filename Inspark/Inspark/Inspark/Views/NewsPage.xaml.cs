using Inspark.Models;
using Inspark.Viewmodels;
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
	public partial class NewsPage : ContentPage
	{
		public NewsPage ()
		{
			InitializeComponent();
		}

        public void PostTapped(object sender, ItemTappedEventArgs e)
        {
            NewsPost selected = e.Item as NewsPost;
<<<<<<< HEAD
            var page = new PostPage(selected);
            News.Content = page.Content;
=======

            var page = new PostPage(selected);
            News.Content = page.Content;
           //var page = new PostPage(selected);
            //await Navigation.PushAsync(page);
>>>>>>> 52bb5c4... new register  and login functions
        }

    }
}