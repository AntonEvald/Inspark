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
	public partial class PostPage : ContentPage
	{
        PostViewModel model;

		public PostPage(NewsPost post)
		{
			InitializeComponent ();
            model = new PostViewModel()
            {
                Id = post.Id,
                Description = post.Description,
                Title = post.Title,
                Text = post.Text,
                Picture = post.Picture,
                Sender = post.Sender,
                SenderId = post.SenderId,
                DateTime = post.DateTime,
            };
            Content.BindingContext = model;
		}
<<<<<<< HEAD
=======

        //public PostPage(NewsPost post)
        //{

        //    InitializeComponent();
        //}
>>>>>>> 52bb5c4... new register  and login functions
	}
}