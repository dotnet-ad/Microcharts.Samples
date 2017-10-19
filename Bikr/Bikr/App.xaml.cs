using Xamarin.Forms;

namespace Bikr
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Bootstrapper.Initialize();

            MainPage = new NavigationPage(new HomePage());
        }

        protected override async void OnStart()
        {
            await this.MainPage.Navigation.PushModalAsync(new WelcomePage());
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
