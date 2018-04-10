 using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Inspark.Models;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using XamForms.Controls;

namespace Inspark.Viewmodels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ScheduleViewModel : BaseViewModel
    {
        public ObservableCollection<Event> SpecificDates = new ObservableCollection<Event>();

        public List<Event> Events = new List<Event>();

        public List<GroupEvent> GroupEvent { get; set; }

        private DateTime? _date;

        public DateTime? Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                NotifyPropertyChanged(nameof(Date));
            }
        }

        public void TestList()
        {
            var e = new Event
            {
                Title = "EfterFest",
                Id = "01",
                Location = "Landsvägsgatan",
                Date = new DateTime(2018, 04, 30, 16, 45, 0),
                //IEnumerable<User> Invited 
                //IEnumerable<User> Attending 
                Description = "HejHEj"
            };

            var a = new Event
            {
                Title = "EfterFest2",
                Id = "01",
                Location = "Landsvägsgatan",
                Date = new DateTime(2018, 04, 28, 16, 45, 0),
                //IEnumerable<User> Invited 
                //IEnumerable<User> Attending 
                Description = "HejHEj"
            };


            Events.Add(e);
            Events.Add(a);

        }

        private ObservableCollection<XamForms.Controls.SpecialDate> attendances;

        public ObservableCollection<XamForms.Controls.SpecialDate> Attendances
        {
            get { return attendances; }
            set { attendances = value; NotifyPropertyChanged(nameof(Attendances)); }
        }

        public ICommand DateChosen
        {
            get
            {
                return new Command((obj) => {
                    System.Diagnostics.Debug.WriteLine(obj as DateTime?);
                });
            }
        }

    }
}

                

        
