using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inspark.Viewmodels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inspark.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddUserToGroupPage : ContentPage
	{
		public AddUserToGroupPage ()
		{
            AddUserToGroupViewModel add = new AddUserToGroupViewModel();
			InitializeComponent ();
            test.ItemsSource = add.GroupList;
		}
	}
}