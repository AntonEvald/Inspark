using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inspark.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void HomeIconTapped(object sender, EventArgs e)
        {
            var page = new HomePage();
            Inspark.Content = page.Content;
        }

        public void GroupIconTapped(object sender, EventArgs e)
        {
            var page = new GroupPage();
            Inspark.Content = page.Content;
        }

        public void CompetitionIconTapped(object sender, EventArgs e)
        {
            var page = new CompetitionPage();
            Inspark.Content = page.Content;
        }

        public void ChatIconTapped(object sender, EventArgs e)
        {
            var page = new ChatPage();
            Inspark.Content = page.Content;
        }

        public void ScheduleIconTapped(object sender, EventArgs e)
        {
            var page = new SchedulePage();
            Inspark.Content = page.Content;
        }
    }
}