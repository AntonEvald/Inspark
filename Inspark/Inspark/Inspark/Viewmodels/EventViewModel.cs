﻿using System;
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

        private string _attending;

        public string Attending
        {
            get { return _attending; }
            set
            {
                _attending = value;
                OnPropertyChanged();
            }
        }

        public async void OnLoad()
        {
            var result = await _api.AttendingsEvent(Id);
            var attending = result.Count;
            if (attending < 1)
            {
                Attending = "Inga Personer har tackat jag till eventet";
            }
            else
            {
                Attending = Attending + "har tackat jag till eventet";
            }
        }

        public EventViewModel()
        {
            OnLoad();
        }

        public ICommand IsAttending => new Command(async () =>
        {
            AttendingEventModel model = new AttendingEventModel
            {
                IsComing = true,
                UserId = Settings.UserId,
                EventId = Id
            };

            var IsSuccess = await _api.AttendingEvent(model);
        });

        public ICommand IsNotAttending => new Command(async () =>
        {
            AttendingEventModel model = new AttendingEventModel
            {
                IsComing = false,
                UserId = Settings.UserId,
                EventId = Id
            };

            var IsSuccess = await _api.AttendingEvent(model);
        });
    }
}
