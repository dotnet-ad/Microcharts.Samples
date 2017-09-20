using System;
using Mvvmicro;

namespace Bikr
{
    public class RideItemViewModel
    {
        public RideItemViewModel(Ride model)
        {
            this.model = model;
        }

        private Ride model;

        public int Identifier => model.Identifier;

        public string Title => model.Date.ToString("d");

        public string Distance => (model.Distance / 1000).ToString("F1") + "km";

        public string Speed => model.AverageSpeed.ToString("F1") + "km/h";

        public string Calories => (int)model.Calories + "kcal";

        public string Location => model.Location;

        public string TotalTime => $"{(int)model.TotalTime.TotalHours}:{(int)model.TotalTime.Minutes}";
    }
}
