using System;
using System.Collections.ObjectModel;
using System.Linq;
using Inspark.Models;
using Inspark.Services;
using Xamarin.Forms;

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
            if (events.Count < 1)
            {
                var e = new Event()
                {
                    Title = "Inga event ännu",
                };
                events.Add(e);
            }
            events = new ObservableCollection<Event>(events);
            Events = events;
            Suggestions = events;
        }

        public Command EmptyCommand
        {
            get
            {
                return new Command(Empty);
            }
        }

        public Command SearchCommand
        {
            get
            {
                return new Command(Search);
            }
        }

        private string _keyword;

        public string Keyword
        {
            get { return _keyword; }
            set
            {
                _keyword = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Event> _suggestions;

        public ObservableCollection<Event> Suggestions
        {
            get { return _suggestions; }
            set
            {
                _suggestions = value;
                OnPropertyChanged();
            }
        }

        private void Empty()
        {
            Suggestions = Events;
        }

        private void Search()
        {
            if (_keyword.Length >= 1)
            {
                var suggestionsList = Events.Where(c => c.Title.ToLower().Contains
                 (_keyword.ToLower()));

                var suggestionListCollection = new ObservableCollection<Event>(suggestionsList);
                Suggestions = suggestionListCollection;


            }
            else
            {
                
            }
        }


        public EventListViewModel()
        {
            PopulateList();
        }
    }
}
