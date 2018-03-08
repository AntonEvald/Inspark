﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace Inspark.Viewmodels
{
    public class RegisterViewModel
    {

        Services.ApiServices apiServices = new Services.ApiServices();

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PhoneNumber { get; set; }

        public string Role { get; set; }

        public ICommand RegisterCommand
        {
            
            get 
            {
                return new Command(async()=> {

                    var isSuccess = await apiServices.RegisterAsync(Role, Email, Password);
                
                    if(isSuccess)
                    {
                        
                    }
                
                
                });
            }

        }

    }
}
