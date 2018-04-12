using System;
using System.Collections.ObjectModel;
using Inspark.Models;
using Inspark.Services;

namespace Inspark.Viewmodels
{
    public class EventListViewModel : BaseViewModel
    {
        ApiServices _api = new ApiServices();
        
        private ObservableCollection<Event> _events;

        public ObservableCollection<Event> Events
        {
            get { return _events; }
            set
            {
                if(_events != value)
                {
                    _events = value;
                    OnPropertyChanged();
                }
            }
        }

        public async void PopulateList()
        {
            var events = await _api.GetAllEvents();
            events = new ObservableCollection<Event>(events);
            Events = events;
        }

        public EventListViewModel()
        {
            PopulateList();
        }
    }
}
