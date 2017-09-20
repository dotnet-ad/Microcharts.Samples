using System;
namespace Bikr
{
    public class PointItemViewModel
    {
        private readonly RidePoint model;

        public PointItemViewModel(RidePoint model)
        {
            this.model = model;
        }

        public string Title => $"{(int)model.Time.TotalHours}:{(int)model.Time.Minutes}";

        public string Distance => $"{(int)(model.Distance)}m";
    }
}
