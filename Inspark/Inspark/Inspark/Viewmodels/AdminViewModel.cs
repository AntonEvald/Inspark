using Inspark.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        // https://www.youtube.com/watch?v=GP-HTddAKqQ 

        ObservableCollection<User> users = new ObservableCollection<User>
        {
            new User() { FirstName = "Andreas", LastName = "Dahlin", Email = "andreas@dahlin.se", PhoneNumber = "0707499911", Section = "Handelshögskolan"},
            new User() { FirstName = "Anton", LastName = "Evald", Email = "anton@evald.se", PhoneNumber = "0707499911", Section = "Handelshögskolan"},
            new User() { FirstName = "Philip", LastName = "Karlsson", Email = "philip@karlsson.se", PhoneNumber = "0707499911", Section = "Handelshögskolan"},
            new User() { FirstName = "Max", LastName = "Engberg", Email = "max@engberg.se", PhoneNumber = "0707499911", Section = "Handelshögskolan"},
            new User() { FirstName = "Andreas", LastName = "Daun", Email = "andreas@daun.se", PhoneNumber = "0707499911", Section = "Handelshögskolan"},
            new User() { FirstName = "Pedram", LastName = "Shabani", Email = "pedram@shabani.se", PhoneNumber = "0707499911", Section = "Handelshögskolan"},
            new User() { FirstName = "Patrik", LastName = "Sandström", Email = "patrik@sandstrom.se", PhoneNumber = "0707499911", Section = "Handelshögskolan"},
            new User() { FirstName = "Jesper", LastName = "Bergmark", Email = "jesper@bergmark.se", PhoneNumber = "0707499911", Section = "Handelshögskolan"}
        };

        private string keyword;

        public string Keyword
        {
            get { return keyword; }
            set
            {
                keyword = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<User> suggestions;

        public ObservableCollection<User> Suggestions
        {
            get { return suggestions; }
            set
            {
                suggestions = value;
                OnPropertyChanged();
            }
        }

        public Command SearchCommand
        {
            get
            {
                return new Command(Search);
            }
        }

        private void Search()
        {
            if (keyword.Length >= 1)
            {
                var suggestionsList = users.Where(c => c.FirstName.ToLower().Contains
                 (keyword.ToLower()) || c.LastName.ToLower().Contains(keyword.ToLower()));

                var suggestionListCollection = new ObservableCollection<User>(suggestionsList);
                Suggestions = suggestionListCollection;

            }
            else
            {

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
