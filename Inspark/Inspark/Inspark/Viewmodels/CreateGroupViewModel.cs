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
    public class CreateGroupViewModel
    {
        //public string Name { get; set; }

        ////public Section Section { get; set; }

        ////public bool IsIntroGroup { get; set; }

        public List<Section> SectionsList { get; set; }

        public CreateGroupViewModel()
        {
            SectionsList = GetSections().OrderBy(t => t.Namn).ToList();
        }

        public List<Section> GetSections()
        {
            var sections = new List<Section>()
            {
                new Section {Id = 1, Namn = "Handelshögskolan"},
                new Section {Id = 2, Namn = "Humaniora, utbildnings- och samhällsvetenskap"},
                new Section {Id = 3, Namn = "Hälsovetenskaper"},
                new Section {Id = 4, Namn = "Juridik, psykologi och socialt arbete"},
                new Section {Id = 5, Namn = "Medicinska vetenskaper"},
                new Section {Id = 6, Namn = "Musikhögskolan"},
                new Section {Id = 7, Namn = "Naturvetenskap och teknik"},
                new Section {Id = 8, Namn = "Restaurang- och hotellhögskolan"}
            };

            return sections;
        }

        public class Section
        {
            public int Id { get; set; }
            public string Namn { get; set; }
        }
    }
}
