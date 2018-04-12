using Inspark.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    public class CreateEventViewModel
    {
        private ApiServices _api = new ApiServices();
        
        public string Title { get; set; }
        public string Id { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        // public IEnumerable<User> Invited { get; set; }
        //public IEnumerable<User> Attending { get; set; }
        public string Description { get; set; }
        
        public DateTime StartDate { get; set; }

        public DateTime StartTime { get; set; }

        public ICommand CreateEventCommand => new Command(async () =>
        {
            Date.AddYears(StartDate.Year);
            Date.AddMonths(StartDate.Month);
            Date.AddDays(StartDate.Day);
            Date.AddHours(StartTime.Hour);
            Date.AddMinutes(StartTime.Minute);
            var a = Date;
            var b = Date;
            var isSuccess = await _api.CreateEvent(Title, Location, Date, Description);
        });
    }
    
}