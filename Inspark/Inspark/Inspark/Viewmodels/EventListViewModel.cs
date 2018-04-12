using System;
using System.Collections.ObjectModel;
using Inspark.Models;

namespace Inspark.Viewmodels
{
    public class EventListViewModel
    {
        public ObservableCollection<Event> events = new ObservableCollection<Event>();

        public void PopulateList()
        {
            var exampleEventOne = new Event
            {
                Title = "EfterFest",
                Id = "01",
                Location = "Landsvägsgatan",
                Date = new DateTime(2018, 03, 30, 16, 45, 0),
                //IEnumerable<User> Invited 
                //IEnumerable<User> Attending 
                Description = "HejHEj"
            };

            var exampleEventTwo = new Event
            {
                Title = "EfterFest2",
                Id = "01",
                Location = "Landsvägsgatan",
                Date = new DateTime(2018, 03, 28, 16, 45, 0),
                //IEnumerable<User> Invited 
                //IEnumerable<User> Attending 
                Description = "HejHEj"
            };

            events.Add(exampleEventOne);
            events.Add(exampleEventTwo);
        }
    }
}
