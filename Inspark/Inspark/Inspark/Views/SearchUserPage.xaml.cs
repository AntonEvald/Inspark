using Inspark.Viewmodels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        List<string> colors = new List<string>()
        {
            "Andreas","Philip","Anton","Jesper","Pedram","Patrik","Max","Jonatan","Carl-Adam","Richard","Fredrik","Kim","Marcus","Victor"
        };

        ObservableCollection<string> myColors = new ObservableCollection<string>();

        public SearchUserPage()
		{
			InitializeComponent();
        }

        public void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var color = e.Item as string;

            myColors.Add(color);

            ColorsListView.ItemsSource = myColors;

            SuggestionsListView.IsVisible = false;
        }

        //public void Handle_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    string keyword = ColorsSearchBar.Text;

        //    if (keyword.Length >= 1)
        //    {
        //        var suggestions = colors.Where(c => c.ToLower().Contains
        //         (keyword.ToLower()));

        //        SuggestionsListView.ItemsSource = suggestions;

        //        SuggestionsListView.IsVisible = true;
        //    }
        //    else
        //    {
        //        SuggestionsListView.IsVisible = false;
        //    }

        //}


    }
}