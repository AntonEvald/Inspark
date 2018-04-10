using Inspark.Models;
using Inspark.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        ApiServices api = new ApiServices();

        public async void OnLoad()
        {
            Users = await api.GetAllUsers();
        }

        private ObservableCollection<User> users;

        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged();
            }
        }

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

        private bool isVisible;

        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
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
                var suggestionsList = Users.Where(c => c.FirstName.ToLower().Contains
                 (keyword.ToLower()) || c.LastName.ToLower().Contains(keyword.ToLower()));

                var suggestionListCollection = new ObservableCollection<User>(suggestionsList);
                Suggestions = suggestionListCollection;

                IsVisible = true;
            }
            else
            {
                IsVisible = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AdminViewModel()
        {
            OnLoad();
        }
    }
}
