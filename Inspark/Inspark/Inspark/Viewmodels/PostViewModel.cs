﻿using Inspark.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inspark.Viewmodels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public Byte[] Picture { get; set; }
        public string SenderId { get; set; }
        public User Sender { get; set; }
        public string Author { get; set; }
    }
}