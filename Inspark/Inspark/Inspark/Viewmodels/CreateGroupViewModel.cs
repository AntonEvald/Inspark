using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Inspark.Annotations;
using Inspark.Models;
using Inspark.Services;
using Inspark.Views;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    public class CreateGroupViewModel : BaseViewModel
    {
        // This class is used for the create a group function. 
        private ApiServices _api = new ApiServices();

        private ObservableCollection<Section> _sectionList;

        public ObservableCollection<Section> SectionsList
        {
            get {return _sectionList; }
            set
            {
                if(_sectionList != value)
                {
                    _sectionList = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _groupName;

        public string GroupName
        {
            get { return _groupName; }
            set
            {
                _groupName = value;
                OnPropertyChanged();
            }
        }

        private bool _isIntroGroup;

        public bool IsIntroGroup
        {
            get { return _isIntroGroup; }
            set
            {
                _isIntroGroup = value;
                OnPropertyChanged();
            }
        }

        private Section _groupSection;

        public Section GroupSection
        {
            get { return _groupSection; }
            set
            {
                _groupSection = value;
                OnPropertyChanged();
            }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand GroupCommand => new Command(async () =>
        {
            var group = new Group()
            {
                Name = _groupName,
                IsIntroGroup = _isIntroGroup,
                Section = _groupSection
            };
            if(await _api.CreateGroup(group))
            {
                Message = "Gruppen har skapats!";

                Application.Current.MainPage = new MainPage(new HomePage());
            }
            else
            {
                Message = "Något gick fel.";
            }
        });

        public async void PopulateLists()
        {

            var sections = await _api.GetAllSections();
            sections = new ObservableCollection<Section>(sections);
            SectionsList = sections;
        }

        public CreateGroupViewModel()
        {
            PopulateLists();
        }
    }
}
