using System;
using System.Collections.Generic;
using System.Text;

namespace Inspark.Models
{
    class Event
    {
        public string Title { get; set; }
        public string Id { get; set; }
        public string Location { get; set; }
        public IEnumerable<User> Invited { get; set; }
        public IEnumerable<User> Attending { get; set; }
        public string Description { get; set; }

    }
}
