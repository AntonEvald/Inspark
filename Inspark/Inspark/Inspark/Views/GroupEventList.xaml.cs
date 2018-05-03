using System;
using System.Collections.Generic;
using Inspark.Models;
using Xamarin.Forms;

namespace Inspark.Views
{
    public partial class GroupEventList : ContentPage
    {
        public GroupEventList()
        {
            
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            GroupEvent.Content = new CreateGroupEvents().Content;
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            GroupEvent selected = e.Item as GroupEvent;
            var page = new GroupEventPage(selected);
            GroupEvent.Content = page.Content;
        }

        public void DeleteGroupEvent_Clicked(object sender, EventArgs e)
        {
            var page = new DeleteGroupEventPage();
            GroupEvent.Content = page.Content;
        }
    }
}
