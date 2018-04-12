using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamForms.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Inspark.Viewmodels;
using Inspark.Models;

namespace Inspark.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchedulePage : ContentPage
    {
        List<SpecialDate> dates = new List<SpecialDate>();
        ScheduleViewModel contex = new ScheduleViewModel();

       
        public SchedulePage()
        {
            InitializeComponent();
            contex.TestList();
            foreach (var item in contex.Events)
            {
                var specialDate = new SpecialDate(item.TimeForEvent);
                specialDate.BackgroundColor = Color.Green;
                specialDate.TextColor = Color.White;
                specialDate.Selectable = true;

                dates.Add(specialDate);
            }
            Cal.StartDay = DayOfWeek.Monday;
            Cal.StartDate = DateTime.Now;
            Cal.MinDate = DateTime.Now.AddDays(-1);
            Cal.BindingContext = contex;
            contex.Attendances = new ObservableCollection<SpecialDate>(dates);
            Cal.SelectedDate = (DateTime.Now);
            Cal.SpecialDates = contex.Attendances;
  

        }


        void Handle_DateClicked(object sender, XamForms.Controls.DateTimeEventArgs e)
        {
            var select = Cal.SelectedDate.Value;
            contex.SpecificDates.Clear();
            var result = contex.Events.Where(x => x.TimeForEvent.ToString("yyyy/MM/dd") == select.ToString("yyyy/MM/dd"));

            foreach (var item in result)
            {             
                contex.SpecificDates.Add(item);
            }
            EventView.ItemsSource = contex.SpecificDates;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }

        private void EventView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Event selected = e.Item as Event;
            var page = new EventPage(selected);
            InsparkScheduleList.Content = page.Content;
        }
    }
}