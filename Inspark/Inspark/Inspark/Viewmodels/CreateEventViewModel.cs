using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    public class CreateEventViewModel
    {
        Services.ApiServices apiServices = new Services.ApiServices();
        
        public string Title { get; set; }
        public string Id { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        // public IEnumerable<User> Invited { get; set; }
        //public IEnumerable<User> Attending { get; set; }
        public string Description { get; set; }
        
        DateTime startDate = DateTime.Now;
        public DateTime StartDate { get; set; }

        DateTime startTime = DateTime.Now;
        public DateTime StartTime { get; set; }

        public ICommand CreateEventCommand => new Command(async () =>
        {
            var isSuccess = await apiServices.CreateEvent(Title, Location, Date, Description);
        });
    }
    
}