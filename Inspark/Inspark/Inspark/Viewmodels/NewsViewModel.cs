using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Inspark.Models;

namespace Inspark.Viewmodels
{
    class NewsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<NewsPost> news;

        public ObservableCollection<NewsPost> News
        {
            get { return news; }
            set
            {
                news = value;
                OnPropertyChanged("News");
            }
        }


        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public NewsViewModel()
        {
            News = new ObservableCollection<NewsPost>()
            {
                new NewsPost() { Id = 1, Description = "Info", Text = "Ja", Title = "Titel" },
                new NewsPost() { Id = 2, Description = "Info", Text = "Ja", Title = "Titel" },
                new NewsPost() { Id = 3, Description = "Info", Text = "Ja", Title = "Titel" },
                new NewsPost() { Id = 4, Description = "Info", Text = "Ja", Title = "Titel" },
                new NewsPost() { Id = 5, Description = "Info", Text = "Ja", Title = "Titel" },
                new NewsPost() { Id = 6, Description = "Info", Text = "Ja", Title = "Titel" }
            };
        }
    }
}
