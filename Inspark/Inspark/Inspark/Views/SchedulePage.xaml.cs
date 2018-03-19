using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamForms.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace Inspark.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchedulePage : ContentPage
    {


        public SchedulePage()
        {
            InitializeComponent();
        }

        void Handle_DateClicked(object sender, XamForms.Controls.DateTimeEventArgs e)
        {
            var date = Schedule.SelectedDates;
            selectedDate.Text = date.FirstOrDefault<DateTime>().ToString("dd/MM/yyyy");

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
    }
}