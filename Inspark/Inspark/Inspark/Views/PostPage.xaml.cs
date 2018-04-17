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
            model = new PostViewModel(post);
            Content.BindingContext = model;
		}

        public PostPage(GroupPost post)
        {
            InitializeComponent();
            model = new PostViewModel(post);
            Content.BindingContext = model;
        }
	}
}