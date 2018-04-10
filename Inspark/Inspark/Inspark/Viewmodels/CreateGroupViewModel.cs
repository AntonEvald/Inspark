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
    public class CreateGroupViewModel : INotifyPropertyChanged
    {
        private ApiServices api = new ApiServices();

        private ObservableCollection<Section> sectionList;

        public ObservableCollection<Section> SectionsList
        {
            get {return sectionList; }
            set
            {
                if(sectionList != value)
                {
                    sectionList = value;
                    OnPropertyChanged();
                }
            }
        }

        private string groupName;

        public string GroupName
        {
            get { return groupName; }
            set
            {
                groupName = value;
                OnPropertyChanged();
            }
        }

        private bool isIntroGroup;

        public bool IsIntroGroup
        {
            get { return isIntroGroup; }
            set
            {
                isIntroGroup = value;
                OnPropertyChanged();
            }
        }

        private Section groupSection;

        public Section GroupSection
        {
            get { return groupSection; }
            set
            {
                groupSection = value;
                OnPropertyChanged();
            }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set
            {
                if (message != value)
                {
                    message = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand GroupCommand => new Command(async () =>
        {
            var group = new Group()
            {
                Name = groupName,
                IsIntroGroup = isIntroGroup,
                Section = groupSection
            };
            if(await api.CreateGroup(group))
            {
                Message = "Gruppen har skapats!";

                Application.Current.MainPage = new MainPage(new HomePage());
            }
            else
            {
                Message = "Något gick fel.";
            }
        });

        //public async void FillPickerWithSections()
        //{
        //    SectionsList = await api.GetAllSections();
        //}

        public CreateGroupViewModel()
        {
            //FillPickerWithSections();

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
