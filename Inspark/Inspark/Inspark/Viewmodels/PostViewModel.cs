using Inspark.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace Inspark.Viewmodels
{
    public class PostViewModel : INotifyPropertyChanged
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
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
            CultureInfo culture = new CultureInfo("sv-SE");
            var today = DateTime.Now;
            if(today.Year == Date.Year)
            {
                if ((today.Date - Date.Date).TotalDays < 2)
                {
                    DisplayDate = "Igår " + Date.TimeOfDay;
                    if ((today.Date - Date.Date).TotalHours < 24)
                    {
                        DisplayDate = (today.Hour - Date.Hour).ToString() + " timmar sedan";

                        if ((today.Date - Date.Date).TotalMinutes < 60)
                        {
                            DisplayDate = (today.Minute - Date.Minute).ToString() + " minuter sedan";
                        }
                    }
                }
                else
                {
                    DisplayDate = Date.Month.ToString(culture) + " " + Date.Day.ToString(culture);
                }
            }
            
            else
            {
                DisplayDate = Date.ToString(culture.DateTimeFormat.LongDatePattern, culture);
            }
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
