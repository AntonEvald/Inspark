using Inspark.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ObservableCollection<Score> _score;

        public ObservableCollection<Score> Score
        {
            get { return _score; }
            set
            {
                if (_score != value)
                {
                    _score = value;
                    OnPropertyChanged();
                }
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

        public async void LoadResult()
        {
            var score = await _api.GetAllScore();
            score = new ObservableCollection<Score>(score);
            Score = score;
        }

        public CompetitionViewModel()
        {
            OnLoad();
            LoadResult();
        }
    }
}
