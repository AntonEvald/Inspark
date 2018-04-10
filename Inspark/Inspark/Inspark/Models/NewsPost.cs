using System;
using System.Collections.Generic;
using System.Text;

namespace Inspark.Models
{
    public class NewsPost
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Byte[] Picture { get; set; }
        public string SenderId { get; set; }
        public string Author { get; set; }
    }
}
