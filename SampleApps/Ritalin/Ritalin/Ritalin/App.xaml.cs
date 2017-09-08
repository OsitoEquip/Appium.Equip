using Ritalin.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Ritalin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();
        }

        public static void SetMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse",
                        AutomationId = "BrowseTab",
                        Icon = Device.OnPlatform("tab_feed.png",null,"tab_feed.png")
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        AutomationId = "AboutTab",
                        Icon = Device.OnPlatform("tab_about.png",null,null)
                    },
                }
            };
        }
    }
}
