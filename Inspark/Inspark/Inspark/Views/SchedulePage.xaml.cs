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
            var specialDate = new SpecialDate(new DateTime(2018, 03, 26));
            specialDate.BackgroundColor = Color.Green;
            specialDate.TextColor = Color.White;
            specialDate.Selectable = true;

            dates.Add(specialDate);
            cal.SpecialDates = dates;
            cal.StartDay = DayOfWeek.Monday;
            cal.BindingContext = contex;
            contex.Attendances = new ObservableCollection<SpecialDate>(dates);
            cal.SelectedDate = (DateTime.Now);
        }

        void Handle_DateClicked(object sender, XamForms.Controls.DateTimeEventArgs e)
        {
            var select = cal.SelectedDate.Value;


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
    }
}