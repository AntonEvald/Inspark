﻿using Inspark.Models;
using Inspark.Services;
using Inspark.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    public class DeleteEventViewModel : BaseViewModel
    {
        ApiServices _api = new ApiServices();
        private ObservableCollection<Event> _eventList;

        private ObservableCollection<Event> _events;

        public ObservableCollection<Event> Events
        {
            get { return _events; }
            set
            {
                if (_events != value)
                {
                    _events = value;
                    OnPropertyChanged();
                }
            }
        }

        private Group _selectedEvent;

        public Group SelectedEvent
        {
            get { return _selectedEvent; }
            set
            {
                if (_selectedEvent != value)
                {
                    _selectedEvent = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged();
                }
            }
        }

        public async void PopulateList()
        {
            _eventList = await _api.GetAllEvents();
            Events = _eventList;
        }

        public DeleteEventViewModel()
        {
            _eventList = new ObservableCollection<Event>();
            PopulateList();
        }

        public ICommand DeleteEvent => new Command(async () =>
        {
            var eventId = SelectedEvent.Id;
            var isSuccess = await _api.DeleteEvent(eventId);
            if (!isSuccess)
            {
                Message = "Något Gick fel";
            }
            else
            {
                Application.Current.MainPage = new MainPage(new AdminPage());
            }
        });



    }
}