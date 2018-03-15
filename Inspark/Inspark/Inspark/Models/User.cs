using System;
using System.Collections.Generic;
using System.Text;

namespace Inspark.Models
{
    public class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string Section { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
