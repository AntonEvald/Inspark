using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    class SearchUserViewModel : INotifyPropertyChanged
    {

        List<string> colors = new List<string>()
        {
            "Andreas","Philip","Anton","Jesper","Pedram","Patrik","Max","Jonatan","Carl-Adam","Richard","Fredrik","Kim","Marcus","Victor"
        };

        private string _keyword;

        public string Keyword
        {
            get { return _keyword; }
            set
            {
                _keyword = value;
                OnPropertyChanged();
            }
        }

        private List<string> _suggestions;

        public List<string> Suggestions
        {
            get { return _suggestions; }
            set
            {
                _suggestions = value;
                OnPropertyChanged();
            }
        }

        //public ICommand SearchCommand => new Command(() =>
        //{
        //    if (_keyword.Length >= 1)
        //    {
        //        Suggestions = colors.Where(c => c.ToLower().Contains
        //         (_keyword.ToLower())).ToList();

        //        //SuggestionsListView.IsVisible = true;
        //    }
        //    else
        //    {
        //        //SuggestionsListView.IsVisible = false;
        //    }
        //});

        public Command SearchCommand
        {
            get
            {
                return new Command(Search);
            }
        }

        private void Search()
        {
            if (_keyword.Length >= 1)
            {
                Suggestions = colors.Where(c => c.ToLower().Contains
                 (_keyword.ToLower())).ToList();

                //SuggestionsListView.IsVisible = true;
            }
            else
            {
                //SuggestionsListView.IsVisible = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string 
            propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs
                (propertyName));
        }
    }
}
