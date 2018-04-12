using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inspark.Models;
using Inspark.Viewmodels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inspark.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EventPage : ContentPage
	{
        EventViewModel model;

        public EventPage (Event e)
		{
            model = new EventViewModel{
                Title = e.Title,
                Id = e.Id,
                Location = e.Location,
                Date = e.TimeForEvent,
                Description = e.Description
            };

			InitializeComponent ();

            Content.BindingContext = model;
		}
	}
}