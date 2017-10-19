namespace Bikr.UWP
{
    public sealed partial class MainPage 
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new Bikr.App());
        }
    }
}