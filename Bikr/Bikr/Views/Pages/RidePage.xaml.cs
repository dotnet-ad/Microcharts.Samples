using System;
using System.Collections.Generic;
using Mvvmicro;
using Xamarin.Forms;

namespace Bikr
{
    public partial class RidePage : ContentPage
    {
        public RidePage()
        {
            this.BindingContext = Container.Default.Get<RideDetailViewModel>();

            InitializeComponent();
        }

        public int RideIdentifier
        {
            set => ((RideDetailViewModel)this.BindingContext).RideIdentifier = value;
        }
    }
}
