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
	public partial class GroupPage : ContentPage
	{
		public GroupPage ()
		{
			InitializeComponent ();
            GroupView.Content = new GroupPostsPage().Content;
		}

        public void Members_Tapped(object sender, EventArgs e)
        {

        }

        public void Events_Tapped(object sender, EventArgs e)
        {

        }

        public void Fadder_Tapped(object sender, EventArgs e)
        {
            GroupView.Content = new FadderPage().Content;
        }

        public void Messages_Tapped(object sender, EventArgs e)
        {

        }

        public void Home_Tapped(object sender, EventArgs e)
        {
            GroupView.Content = new GroupPostsPage().Content;
        }
    }
}