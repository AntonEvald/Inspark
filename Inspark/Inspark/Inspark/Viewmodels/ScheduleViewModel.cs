using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Inspark.Models;

namespace Inspark.Viewmodels
{
    class ScheduleViewModel
    {
        public ICollection<Event> Events { get; set; }

        public ObservableCollection<Event> GetSchedule()
        {
            //grejer
            return new ObservableCollection<Event>();
        }
    }
}
