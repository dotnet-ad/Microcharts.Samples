using Mvvmicro;

namespace Bikr
{
    public static class Bootstrapper
    {
        public static void Initialize()
        {
            // Services
            Container.Default.Register<IRideRepository>((c) => new SampleRideRepository(), isInstance: true);

            // ViewModels
            Container.Default.Register((c) => new HomeViewModel(c.Get<IRideRepository>()));
            Container.Default.Register((c) => new RideDetailViewModel(c.Get<IRideRepository>()));
        }
    }
}
