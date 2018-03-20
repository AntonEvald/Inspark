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
                var specialDate = new SpecialDate(item.date);
                specialDate.BackgroundColor = Color.Green;
                specialDate.TextColor = Color.White;
                specialDate.Selectable = true;

                dates.Add(specialDate);
            }
            cal.StartDay = DayOfWeek.Monday;
            cal.StartDate = DateTime.Now;
            cal.MinDate = DateTime.Now.AddDays(-1);
            cal.BindingContext = contex;
            contex.Attendances = new ObservableCollection<SpecialDate>(dates);
            cal.SelectedDate = (DateTime.Now);
            cal.SpecialDates = contex.Attendances;
  

        }


        void Handle_DateClicked(object sender, XamForms.Controls.DateTimeEventArgs e)
        {
            var select = cal.SelectedDate.Value;
            contex.SpecificDates.Clear();
            var result = contex.Events.Where(x => x.date.ToString("yyyy/MM/dd") == select.ToString("yyyy/MM/dd"));

            foreach (var item in result)
            {
                var title = item.Title;
                contex.SpecificDates.Add(title);
            }
            EventView.ItemsSource = contex.SpecificDates;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
    }
}