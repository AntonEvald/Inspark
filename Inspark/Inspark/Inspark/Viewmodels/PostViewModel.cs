using Inspark.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace Inspark.Viewmodels
{
    public class PostViewModel : BaseViewModel
    {
        public PostViewModel(NewsPost post)
        {
            Id = post.Id;
            Title = post.Title;
            Text = post.Text;
            Date = post.Date;
            Picture = post.Picture;
            SenderId = post.SenderId;
            Author = post.Author;
            SetDisplayDate();
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public Byte[] Picture { get; set; }
        public string SenderId { get; set; }
        public string Author { get; set; }

        private string _displayDate;

        public string DisplayDate
        {
            get { return _displayDate; }
            set
            {
                if(_displayDate != value)
                {
                    _displayDate = value;
                    OnPropertyChanged();
                }           
            }
        }

        public void SetDisplayDate()
        {
            CultureInfo culture = new CultureInfo("sv-SE");
            var today = DateTime.Now;
            if (today.Year == Date.Year)
            {
                DisplayDate = Date.Month.ToString(culture) + " " + Date.Day.ToString(culture);
                if (today.Month == Date.Month)
                {
                    if (today.Date.AddDays(-1) == Date.Date)
                    {
                        DisplayDate = "Igår " + Date.Hour.ToString() + ":" + Date.Minute.ToString();
                    }
                    if (today.Day == Date.Day)
                    {
                        DisplayDate = (today.Hour - Date.Hour).ToString() + " timmar sedan";
                        if (today.Hour == Date.Hour)
                        {
                            DisplayDate = (today.Minute - Date.Minute).ToString() + " minuter sedan";
                            if (today.Minute == Date.Minute)
                            {
                                DisplayDate = "Alldeles nyss";
                            }
                        }
                    }
                }
                else
                {
                    DisplayDate = Date.Day.ToString() + " " + Date.ToString("MMMM", culture);
                }
            }
            else
            {
                DisplayDate = Date.ToString(culture.DateTimeFormat.LongDatePattern, culture);
            }
        }
    }
}
