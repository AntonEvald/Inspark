using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inspark.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Inspark;
using Inspark.Models;

namespace Inspark.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdminPage : ContentPage
	{
		public AdminPage ()
		{
			InitializeComponent ();
		    SuggestionsListView.IsVisible = false;
        }

        public void CreateGroupButton_Clicked(object sender, EventArgs e)
        {
            var page = new CreateGroupPage();
            InsparkAdmin.Content = page.Content;
        }

        public void ChangeGroupButton_Clicked(object sender, EventArgs e)
        {
            var page = new ChangeGroupPage();
            InsparkAdmin.Content = page.Content;
        }

	    public void DeleteGroupButton_Clicked(object sender, EventArgs e)
	    {
	        var page = new DeleteGroupPage();
	        InsparkAdmin.Content = page.Content;
	    }

        //ApiServices apiServices = new ApiServices();

        //public async void GetUsers()
        //{
        //    var user = await apiServices.GetAllUsers();

        //    foreach (var item in user)
        //    {
        //        users.Add(item);
        //    }
        //}

        // Collection of users, repalce with the database content when API works. 
        ObservableCollection<User> users = new ObservableCollection<User>
        {
            new User { Id = 1, FirstName = "Andreas", LastName = "Dahlin", Email = "andreas@dahlin.se", PhoneNumber = "0707499911", Section = "Handelshögskolan"},
            new User { Id = 2, FirstName = "Anton", LastName = "Evald", Email = "anton@evald.se", PhoneNumber = "0707499911", Section = "Handelshögskolan"},
            new User { Id = 3, FirstName = "Philip", LastName = "Karlsson", Email = "philip@karlsson.se", PhoneNumber = "0707499911", Section = "Handelshögskolan"},
            new User { Id = 4, FirstName = "Max", LastName = "Engberg", Email = "max@engberg.se", PhoneNumber = "0707499911", Section = "Handelshögskolan"},
            new User { Id = 5, FirstName = "Andreas", LastName = "Daun", Email = "andreas@daun.se", PhoneNumber = "0707499911", Section = "Handelshögskolan"},
            new User { Id = 6, FirstName = "Pedram", LastName = "Shabani", Email = "pedram@shabani.se", PhoneNumber = "0707499911", Section = "Handelshögskolan"},
            new User { Id = 7, FirstName = "Patrik", LastName = "Sandström", Email = "patrik@sandstrom.se", PhoneNumber = "0707499911", Section = "Handelshögskolan"},
            new User { Id = 8, FirstName = "Jesper", LastName = "Bergmark", Email = "jesper@bergmark.se", PhoneNumber = "0707499911", Section = "Handelshögskolan"}
        };

	    // Gets the name of the user where the firstname or the lastname matches the keyword from the searchbar and adds the user to the ListView. 
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

        // Displays a ProfilePage of the user that is tapped on from the ListView. 
        public void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            User selected = e.Item as User;
            var page = new ProfilePage(selected);
            InsparkAdmin.Content = page.Content;
        }


	}
}