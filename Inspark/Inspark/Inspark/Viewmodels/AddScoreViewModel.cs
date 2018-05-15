using Inspark.Helpers;
using Inspark.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    public class AddScoreViewModel : BaseViewModel
    {
        private int _score;

        public int Score
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

        private ObservableCollection<Group> _groups;

        public ObservableCollection<Group> Groups
        {
            get { return _groups; }
            set
            {
                if (_groups != value)
                {
                    _groups = value;
                    OnPropertyChanged();
                }
            }
        }

        private Group _selectedGroup;

        public Group SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                if (_selectedGroup != value)
                {
                    _selectedGroup = value;
                    OnPropertyChanged();
                }
            }
        }

        public async void PopulateList()
        {
            var groups = await _api.GetAllGroups();
            groups = new ObservableCollection<Group>(groups);
            Groups = groups;
        }

        public AddScoreViewModel()
        {
            PopulateList();
        }

        public ICommand AddScore => new Command(async () =>
        {
            var score = await _api.GetAllScore();
            Score newscore = score.First(x => x.Id == SelectedGroup.Id);
            var result = newscore.TotalPoints + Score;

            var model = new Score
            {
                TotalPoints = result,
                GroupID = SelectedGroup.Id
            };
        });
    }
}
