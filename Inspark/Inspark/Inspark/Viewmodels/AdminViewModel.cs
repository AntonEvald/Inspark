using System;
using System.Collections.Generic;
using System.Text;
using Inspark.Views;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Inspark.Services;

namespace Inspark.Viewmodels
{
    class AdminViewModel
    {
        private ApiServices apiServices = new ApiServices();

        public string SearchUser { get; set; }
        public List<string> UserList { get; set; }
        public string ErrorMessage { get; set; }
        public ICommand SearchCommand { get; set; }

        //public async void SearchPressed()
        //{
        //    var allUsers = await apiServices.GetAllUsers();
        //    var result = allUsers.Where(x => x.FirstName == SearchUser);

        //    if(result == null)
        //    {
        //        ErrorMessage = "Inga användare";
        //    }
        //    else
        //    {
        //        foreach (var item in allUsers)
        //        {
        //            var firstName = item.FirstName;
        //            UserList.Add(firstName);
        //        }
        //    }
        //}

        public ICommand SearchPressed => new Command(async () =>
        {
            var allUsers = await apiServices.GetAllUsers();
            var result = allUsers.Where(x => x.FirstName == SearchUser);

            if (result == null)
            {
                ErrorMessage = "Inga användare";
            }
            else
            {
                foreach (var item in allUsers)
                {
                    var firstName = item.FirstName;
                    UserList.Add(firstName);
                }
            }
        });
    }
}
