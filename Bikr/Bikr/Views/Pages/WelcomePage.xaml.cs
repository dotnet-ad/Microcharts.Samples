namespace Bikr
{
    using Xamarin.Forms;

    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await this.Navigation.PopModalAsync();
        }
    }
}
