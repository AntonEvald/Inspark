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

        public void Icon1_Tapped(object sender, EventArgs e)
        {
            var page = new HomePage();
            PlaceHolder.Content = page.Content;
        }

        public void Icon2_Tapped(object sender, EventArgs e)
        {
            var page = new GroupPage();
            PlaceHolder.Content = page.Content;
        }

        public void Icon3_Tapped(object sender, EventArgs e)
        {
            var page = new CompetitionPage();
            PlaceHolder.Content = page.Content;
        }

        public void Icon4_Tapped(object sender, EventArgs e)
        {
            var page = new ChatPage();
            PlaceHolder.Content = page.Content;
        }

        public void Icon5_Tapped(object sender, EventArgs e)
        {
            var page = new SchedulePage();
            PlaceHolder.Content = page.Content;
        }
    }
}