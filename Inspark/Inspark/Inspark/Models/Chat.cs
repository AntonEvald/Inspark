using System;
using System.Collections.Generic;
using System.Text;

namespace Inspark.Models
{
    public class Chat
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Message> Messages { get; set; }
        public int Id { get; set; }
    }
}
