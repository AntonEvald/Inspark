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
	public partial class SearchUserPage : ContentPage
	{
        private readonly List<string> userList = new List<string>()
        {
            "Andreas","Philip","Anton","Jesper","Pedram","Patrik","Max"
        };

		public SearchUserPage()
		{
			InitializeComponent ();
            UserList.ItemsSource = userList;
		}
        
        public void SearchClicked(object sender, EventArgs e)
        {
            string keyword = SearchUser.Text;
            IEnumerable<string> result = userList.Where(name => name.ToLower().Contains(keyword.ToLower()));
            UserList.ItemsSource = result;
        }


    }
}