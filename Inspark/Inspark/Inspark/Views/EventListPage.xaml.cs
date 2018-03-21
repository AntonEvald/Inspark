using System;
using System.Collections.Generic;
using Inspark.Models;
using Inspark.Viewmodels;
using Xamarin.Forms;

namespace Inspark.Views
{
    public partial class EventListPage : ContentPage
    {
        //public EventListViewModel eventListViewModel = new EventListViewModel();

        //public EventListPage()
        //{
        //    InitializeComponent();
        //    eventListViewModel.PopulateList();
        //    EventList.ItemsSource = eventListViewModel.events;
        //}

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Event selected = e.Item as Event;
            var page = new EventPage(selected);
            InsparkEventList.Content = page.Content;
        }
    }
}
