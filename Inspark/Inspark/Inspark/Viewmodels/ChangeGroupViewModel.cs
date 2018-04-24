using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Inspark.Models;
using Inspark.Services;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    public class ChangeGroupViewModel : BaseViewModel
    {

        ApiServices _api = new ApiServices();


        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
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

        private ObservableCollection<Section> _sectionList;

        public ObservableCollection<Section> SectionsList
        {
            get { return _sectionList; }
            set
            {
                if (_sectionList != value)
                {
                    _sectionList = value;
                    OnPropertyChanged();
                }
            }
        }

        private Section _selectedSection;

        public Section SelectedSections
        {
            get { return _selectedSection; }
            set
            {
                if (_selectedSection != value)
                {
                    _selectedSection = value;
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

        public ICommand SelectedProviderChanged => new Command(() =>
        {
            Name = SelectedGroup.Name;
            IsIntroGroup = SelectedGroup.IsIntroGroup;
            SelectedSections = SelectedGroup.Section;
        });

        //public ICommand ChangeGroup => new Command(async () =>
        //{

        //    var isSuccess = await _api.ChangeGroup();

        //});

        public async void PopulateLists()
        {

            var groups = await _api.GetAllGroups();
            groups = new ObservableCollection<Group>(groups);
            Groups = groups;
        }

        public ChangeGroupViewModel()
        {
            PopulateLists();
            SectionsList = new ObservableCollection<Section>()
            {
                new Section() {Id = 1, Name = "Handelshögskolan"},
                new Section() {Id = 2, Name = "Humaniora, utbildnings- och samhällsvetenskap"},
                new Section() {Id = 3, Name = "Hälsovetenskaper"},
                new Section() {Id = 4, Name = "Juridik, psykologi och socialt arbete"},
                new Section() {Id = 5, Name = "Medicinska vetenskaper"},
                new Section() {Id = 6, Name = "Musikhögskolan"},
                new Section() {Id = 7, Name = "Naturvetenskap och teknik"},
                new Section() {Id = 8, Name = "Restaurang- och hotellhögskolan"}
            };
        }
    }
}
