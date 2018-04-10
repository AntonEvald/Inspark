using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Input;
using Inspark.Models;
using Inspark.Services;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    public class AddUserToGroupViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<User> UserList { get; set; }
        public ObservableCollection<Group> GroupList { get; set; }
        private readonly ApiServices _api = new ApiServices();

        public AddUserToGroupViewModel()
        {
            LoadCommand.Execute(null);
            var b = GroupList;
            var a = GroupList;
            
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    

        public Command LoadCommand
        {
            get
            {
                return new Command(async (obj) =>
                {
                    GroupList = await _api.GetAllGroups();
                });
            }
        }
    }
}