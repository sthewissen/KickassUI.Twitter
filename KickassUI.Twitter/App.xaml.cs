using FreshMvvm;
using KickassUI.Twitter.PageModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace KickassUI.Twitter
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var masterDetailsMultiple = new MasterDetailPage();

            var menuPage = FreshPageModelResolver.ResolvePageModel<MenuPageModel>();
            masterDetailsMultiple.Master = menuPage;

            var container = new FreshTabbedNavigationContainer();
            container.AddTab<MainPageModel>("Main page", "icon-home.png", null);
            container.AddTab<MainPageModel>("Main page", "icon-search.png", null);
            container.AddTab<MainPageModel>("Main page", "icon-bell.png", null);
            container.AddTab<MainPageModel>("Main page", "icon-dm.png", null);

            masterDetailsMultiple.Detail = container;

            MainPage = masterDetailsMultiple;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
