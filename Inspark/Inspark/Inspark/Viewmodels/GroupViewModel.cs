using Inspark.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inspark.Viewmodels
{
    class GroupViewModel : BaseViewModel
    {
        private ApiServices _api = new ApiServices();

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

        public async void OnLoad()
        {
            var user = await _api.GetLoggedInUser();
            if (user.Role == "Admin" || user.Role == "Fadder")
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
