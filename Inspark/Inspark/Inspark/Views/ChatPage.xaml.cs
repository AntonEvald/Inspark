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
	public partial class ChatPage : ContentPage
	{
        ChatViewModel vm;

		public ChatPage ()
		{
			InitializeComponent ();
            BindingContext = vm = new ChatViewModel();

            MessagesListView.ItemsSource = vm.Messages;

            vm.Messages.CollectionChanged += (sender, e) =>
            {
                var target = vm.Messages[vm.Messages.Count - 1];
                MessagesListView.ScrollTo(target, ScrollToPosition.End, true);
                MessagesListView.ItemsSource = null;
                MessagesListView.ItemsSource = vm.Messages;
            };
        }

        
        

        void MyListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MessagesListView.SelectedItem = null;
        }

        void MyListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            MessagesListView.SelectedItem = null;
        }
    }
}