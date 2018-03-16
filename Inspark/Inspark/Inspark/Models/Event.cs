﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Inspark.Models
{
    class Event
    {
        public string Title { get; set; }
        public string Id { get; set; }
        public string Location { get; set; }
        public DateTime date { get; set; }
        public IEnumerable<User> Invited { get; set; }
        public IEnumerable<User> Attending { get; set; }
        public string Description { get; set; }

    }

    class groupEvent
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public byte[] Picture { get; set; }
        public User Sender { get; set; }
        public int senderId { get; set; }
        //public Group Group { get; set; }
        public int GroupId { get; set; }
    }
}
