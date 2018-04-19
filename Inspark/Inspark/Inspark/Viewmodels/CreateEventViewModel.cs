using Inspark.Services;
using System;
using System.Windows.Input;
using Inspark.Views;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    public class CreateEventViewModel : BaseViewModel
    {
        private ApiServices _api = new ApiServices();
        
        public string Title { get; set; }
        public string Id { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        // public IEnumerable<User> Invited { get; set; }
        //public IEnumerable<User> Attending { get; set; }
        public string Description { get; set; }

        
        private DateTime _startTime;

        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged();
            }
        }
        
        private string _message;            
                                          
        public string Message               
        {                                       
            get { return _message; }          
            set                                 
            {                                   
                _message = value;             
                OnPropertyChanged();            
            }                                   
        }    

        private bool _IsButtonEnabled { get; set; }
        public bool IsButtonEnabled
        {
            get { return _IsButtonEnabled; }
            set
            {
                _IsButtonEnabled = value;
                OnPropertyChanged();
            }
        }

        
        private DateTime _startDate;

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged();
            }
        }

        public ICommand CreateEventCommand => new Command(async () =>
        {
            DateTime newDateTime = StartDate.Date.Add(StartTime.TimeOfDay);
            Date = newDateTime;
            var isSuccess = await _api.CreateEvent(Title, Location, Date, Description);

            if (isSuccess)
            {
                Application.Current.MainPage = new MainPage(new EventListPage());
            }
            else
            {
                Message = "Något gick fel";
            }    
        });
    }
    
}