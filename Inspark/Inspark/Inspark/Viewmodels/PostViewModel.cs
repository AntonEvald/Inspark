using Inspark.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Inspark.Viewmodels
{
    public class PostViewModel : INotifyPropertyChanged
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public Byte[] Picture { get; set; }
        public string SenderId { get; set; }
        public User Sender { get; set; }
        public string Author { get; set; }
        

        public event PropertyChangedEventHandler PropertyChanged;

        private string _displayDate;

        public string DisplayDate
        {
            get { return _displayDate; }
            set
            {
                if(_displayDate != value)
                {
                    _displayDate = value;
                    OnPropertyChanged("DisplayDate");
                }           
            }
        }

        public PostViewModel()
        {
            SetDisplayDate();
        }

        public void SetDisplayDate()
        {
            var today = DateTime.Now;
            if((today.Date - DateTime.Date).TotalDays < 2)
            {
                DisplayDate = "Igår";
                if ((today.Date - DateTime.Date).TotalHours < 24)
                {
                    DisplayDate = (today.Hour - DateTime.Hour).ToString() + " timmar sedan";

                    if((today.Date - DateTime.Date).TotalMinutes < 60)
                    {
                        DisplayDate = (today.Minute - DateTime.Minute).ToString() + " minuter sedan";
                    }
                }
            }
            else
            {
                DisplayDate = DateTime.ToShortDateString();
            }
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
