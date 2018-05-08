using Inspark.Helpers;
using Inspark.Models;
using Inspark.Services;
using Inspark.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    class GroupViewModel : BaseViewModel
    {
        private Group _group;

        public Group Group
        {
            get { return _group; }
            set
            {
                _group = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Group> _groups;

        public ObservableCollection<Group> Groups
        {
            get { return _groups; }
            set
            {
                _groups = value;
                OnPropertyChanged();
            }
        }

        private bool _isVisible;

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                OnPropertyChanged();
            }
        }

        public  void OnLoad()
        {
            ////var groups = await _api.GetAllGroupsByUserId();
            ////if (groups.Count > 1)
            ////{
            //    //Groups = groups;
            //    //Application.Current.MainPage = new MainPage(new SelectGroupPage());
            //}
            if (Settings.UserRole == "Admin" || Settings.UserRole == "Fadder")
            {
                IsVisible = true;
            }
        }

        public GroupViewModel()
        {
            OnLoad();
        }

    }
}
