using System;
using System.Collections.Generic;
using Inspark.Models;
using Inspark.Viewmodels;
using Xamarin.Forms;

namespace Inspark.Views
{
    public partial class GroupEventPage : ContentPage
    {

        GroupEventViewModel model;

        public GroupEventPage(GroupEvent e)
        {

            model = new GroupEventViewModel
            {
                Title = e.Title,
                Id = e.Id,
                Location = e.Location,
                Date = e.TimeForEvent,
                Description = e.Description
            };

            InitializeComponent();
            Content.BindingContext = model;
        }
    }
}
