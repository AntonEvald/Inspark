using System;
using System.Collections.ObjectModel;
using System.Linq;
using Inspark.Models;
using Inspark.Services;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    public class GroupEventListViewModel : BaseViewModel
    {
        public GroupEventListViewModel()
        {
            PopulateList();
        }

        ApiServices _api = new ApiServices();

        private ObservableCollection<GroupEvent> _events;

        public ObservableCollection<GroupEvent> Events
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

        public async void PopulateList()
        {
            var events = await _api.GetAllGroupEvents();
            if (events.Count < 1)
            {
                var e = new GroupEvent()
                {
                    Title = "Inga event ännu",
                };
                events.Add(e);
            }
            events = new ObservableCollection<GroupEvent>(events);
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

        private ObservableCollection<GroupEvent> _suggestions;

        public ObservableCollection<GroupEvent> Suggestions
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

                var suggestionListCollection = new ObservableCollection<GroupEvent>(suggestionsList);
                Suggestions = suggestionListCollection;


            }
            else
            {

            }
        }
    }
}
