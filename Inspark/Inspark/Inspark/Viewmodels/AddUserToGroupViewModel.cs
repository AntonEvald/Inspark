using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Input;
using Inspark.Models;
using Inspark.Services;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    public class AddUserToGroupViewModel
    {
        public ObservableCollection<User> UserList { get; set; }
        public ObservableCollection<Group> GroupList { get; set; }
        private readonly ApiServices _api = new ApiServices();

        public AddUserToGroupViewModel()
        {
            GetAllUsersCommand.Execute(null);
            
        }

        private ICommand GetAllUsersCommand
        {
            get
            {
                return new Command(async () => UserList = await _api.GetAllUsers());
            }
        }
        
        private ICommand GetAllGroupsCommand
        {
            get
            {
                return new Command(async () => { GroupList = await _api.GetAllGroups(); });
            }
        }
    }
}