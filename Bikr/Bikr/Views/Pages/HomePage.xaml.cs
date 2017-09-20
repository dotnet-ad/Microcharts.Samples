namespace Bikr
{
    using Mvvmicro;
    using Xamarin.Forms;

    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            this.BindingContext = Container.Default.Get<HomeViewModel>();

            InitializeComponent();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as RideItemViewModel;
            if(item != null)
            {
                var page = new RidePage();
                page.RideIdentifier = item.Identifier;
                await this.Navigation.PushAsync(page);
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}
