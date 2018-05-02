using System;
using System.Collections.Generic;
using System.Windows.Input;
using Inspark.Helpers;
using Inspark.Models;
using Inspark.Services;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    public class EventViewModel : BaseViewModel
    {
        private ApiServices _api = new ApiServices();

        public string Title { get; set; }
        public int Id { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        //public IEnumerable<User> Invited { get; set; }
        //public IEnumerable<User> Attending { get; set; }
        public string Description { get; set; }

        public ICommand IsAttending => new Command(async () =>
        {
            AttendingModel model = new AttendingModel
            {
                IsComing = true,
                UserId = Settings.UserId,
                GroupEventId = Id
            };

            var IsSuccess = await _api.Attending(model);
        });

        public ICommand IsNotAttending => new Command(async () =>
        {
            AttendingModel model = new AttendingModel
            {
                IsComing = false,
                UserId = Settings.UserId,
                GroupEventId = Id
            };

            var IsSuccess = await _api.Attending(model);
        });
    }
}
