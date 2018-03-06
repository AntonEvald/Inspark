using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Inspark
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            Title = "Inspark";
		}

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync(new Login());
        }
    }
}
