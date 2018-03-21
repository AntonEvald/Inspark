using Inspark.Models;
using Inspark.Services;
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
        //ApiServices apiServices = new ApiServices();

        //public async void GetUsers()
        //{
        //    var user = await apiServices.GetAllUsers();

        //    foreach (var item in user)
        //    {
        //        users.Add(item);
        //    }
        //}

        ObservableCollection<User> users = new ObservableCollection<User>()
        {
            new User() { Id = 1, FirstName = "Andreas", LastName = "Dahlin"},
            new User() { Id = 2, FirstName = "Anton", LastName = "Evald"},
            new User() { Id = 3, FirstName = "Philip", LastName = "Karlsson"},
            new User() { Id = 4, FirstName = "Max", LastName = "Engberg"},
            new User() { Id = 5, FirstName = "Andreas", LastName = "Daun"},
            new User() { Id = 6, FirstName = "Pedram", LastName = "Shabani"},
            new User() { Id = 7, FirstName = "Patrik", LastName = "Sandström"},
            new User() { Id = 8, FirstName = "Jesper", LastName = "Bergmark"}
        };

        public SearchUserPage()
		{
			InitializeComponent();
        }

        public void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = UserSearchBar.Text;

            if (keyword.Length >= 1)
            {
                var suggestions = users.Where(c => c.FirstName.ToLower().Contains
                 (keyword.ToLower()) || c.LastName.ToLower().Contains(keyword.ToLower()));

                SuggestionsListView.ItemsSource = suggestions;

                SuggestionsListView.IsVisible = true;
            }
            else
            {
                SuggestionsListView.IsVisible = false;
            }
        }
    }
}