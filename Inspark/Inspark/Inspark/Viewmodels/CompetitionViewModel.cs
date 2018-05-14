using Inspark.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inspark.Viewmodels
{
    public class CompetitionViewModel : BaseViewModel
    {
        public User User { get; set; }

        private bool _isAdmin;

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                _isAdmin = value;
                OnPropertyChanged();
            }
        }

        public async void OnLoad()
        {
            User = await _api.GetLoggedInUser();

            if (User.Role == "Admin")
            {
                IsAdmin = true;
            }
            else
            {
                IsAdmin = false;
            }
        }

        public CompetitionViewModel()
        {
            OnLoad();
        }
    }
}
