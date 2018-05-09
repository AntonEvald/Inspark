using System;
using System.Collections.Generic;
using System.Text;

namespace Inspark.Models
{
    public class GroupChat
    {
        public string ChatName { get; set; }
        public virtual Group Group { get; set; }
        public int Id { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}
