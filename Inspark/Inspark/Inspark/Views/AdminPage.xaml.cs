using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inspark.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Inspark;

namespace Inspark.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdminPage : ContentPage
	{
		public AdminPage ()
		{
			InitializeComponent ();
		}

        public void CreateGroupButton_Clicked(object sender, EventArgs e)
        {
            var page = new CreateGroup();
            InsparkAdmin.Content = page.Content;
        }

        public void ChangeGroupButton_Clicked(object sender, EventArgs e)
        {
            var page = new ChangeGroup();
            InsparkAdmin.Content = page.Content;
        }
    }
}