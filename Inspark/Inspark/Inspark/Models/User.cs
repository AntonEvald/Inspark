﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Inspark.Models
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ConfirmPassword { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string Section { get; set; }
        public Group Group { get; set; }
    }
}
