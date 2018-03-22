using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inspark.Models;
using Inspark.Viewmodels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inspark.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePage : ContentPage
	{
	    private ProfileViewModel model;
		public ProfilePage (User e)
		{
		    model = new ProfileViewModel
		    {
		        Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
		        PhoneNumber = e.PhoneNumber,
		        Section = e.Section
            };

			InitializeComponent ();
		    Content.BindingContext = model;
        }
	}
}