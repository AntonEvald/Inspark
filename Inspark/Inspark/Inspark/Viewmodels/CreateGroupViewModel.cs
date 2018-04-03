using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Inspark.Annotations;
using Inspark.Models;

namespace Inspark.Viewmodels
{
    public class CreateGroupViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Section> sectionList;

        public ObservableCollection<Section> SectionsList
        {
            get {return sectionList; }
            set
            {
                if(sectionList != value)
                {
                    sectionList = value;
                    OnPropertyChanged("SectionList");
                }
            }
        }

        public CreateGroupViewModel()
        {
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

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
