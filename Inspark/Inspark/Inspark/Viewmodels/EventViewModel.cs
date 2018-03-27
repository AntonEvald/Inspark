using System;
namespace Inspark.Viewmodels
{
    public class EventViewModel
    {
        public string Title { get; set; }
        public string Id { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        // public IEnumerable<User> Invited { get; set; }
        //public IEnumerable<User> Attending { get; set; }
        public string Description { get; set; }
    }
}
