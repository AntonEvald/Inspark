using System;
using System.Collections.Generic;
using Inspark.Models;
using Inspark.Viewmodels;
using Xamarin.Forms;

namespace Inspark.Views
{
    public partial class EventListPage : ContentPage
    {
        public readonly EventListViewModel EventListViewModel = new EventListViewModel();

        public EventListPage()
        {
            InitializeComponent();
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Event selected = e.Item as Event;
            var page = new EventPage(selected);
            InsparkEventList.Content = page.Content;
        }

        public void CreateEvent_OnClicked(object sender, EventArgs e)
        {
            var page = new CreateEventPage();
            InsparkEventList.Content = page.Content;
        }
    }
}
