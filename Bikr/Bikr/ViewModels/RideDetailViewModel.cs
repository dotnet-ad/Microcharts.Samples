using Microcharts;
using System.Linq;
using System.Collections.Generic;
using System;
namespace Bikr
{
    using Mvvmicro;
    using SkiaSharp;

    public class RideDetailViewModel : ViewModelBase
    {
        public RideDetailViewModel(IRideRepository repository)
        {
            this.repository = repository;
        }

        private readonly IRideRepository repository;

        private int rideIdentifier = -1;

        private Ride ride;

        public int RideIdentifier
        {
            get => this.rideIdentifier;
            set
            {
                if(this.Set(ref this.rideIdentifier, value).HasChanged)
                {
                    this.Update();
                }
            }
        }


        private static readonly SKColor AccentColor = SKColor.Parse("#2C5DF9");

        private static readonly SKColor AccentDarkColor = SKColor.Parse("#484F64");

        private static readonly SKColor OrangeColor = SKColor.Parse("#FFD45F");

        private static readonly SKColor GreenColor = SKColor.Parse("#26C3AC");

        private static readonly SKColor PinkColor = SKColor.Parse("#FA6978");

        public string Title => ride?.Date.ToString("d");

        public IEnumerable<PointItemViewModel> Points => this.ride?.Points?.Select(x => new PointItemViewModel(x)) ?? new PointItemViewModel[0];

        public Ride Goals => this.repository.GetGoals();

        public Chart AltitudeChart => new LineChart()
        {
            Entries = this.ride?.Points.Select(x => new Entry(x.Altitude) 
            {
                Color = AccentColor,
                TextColor = AccentColor,
            }) ?? new Entry[0],
            LineMode = LineMode.Straight,
            PointMode = PointMode.None,
            LineSize = 8,
            BackgroundColor = SKColors.Transparent,
        };

        public Chart DistanceChart => new LineChart()
        {
            Entries = this.ride?.Points.GroupBy(x => ((int)x.Time.TotalMinutes) / 10).Select(x => new Entry(x.First().Distance)
            {
                Color = SKColors.White,
                TextColor = SKColors.White,
                Label = x.First().Time.TotalMinutes.ToString(),
                ValueLabel = (x.First().Distance / 1000).ToString("F1"),
            }) ?? new Entry[0],
            LineMode = LineMode.Straight,
            PointMode = PointMode.Circle,
            LineSize = 1,
            BackgroundColor = SKColors.Transparent,
        };

        public Chart EffortChart => new DonutChart()
        {
            Entries = new[]
            {
                new Entry(this.ride?.TotalUp ?? 0)
                {
                    Color = AccentColor,
                    TextColor = AccentColor,
                    Label = "Up",
                    ValueLabel = $"{this.ride?.TotalUp}m",
                },
                new Entry(this.ride?.TotalDown ?? 0)
                {
                    Color = AccentDarkColor,
                    TextColor = AccentDarkColor,
                    Label = "Down",
                    ValueLabel = $"{this.ride?.TotalDown}m",
                },
            },
            BackgroundColor = SKColors.Transparent,
            HoleRadius = 0.5f,
        };

        public Chart GoalsChart => new RadialGaugeChart()
        {
            Entries = new[]
            {
                new Entry(Math.Min(1,(this.ride?.Calories / Goals.Calories) ?? 0))
                {
                    Color = AccentColor,
                    TextColor = AccentColor,
                    Label = "Calories",
                    ValueLabel = $"{(int?)this.ride?.Calories}/{ (int?)Goals.Calories}",
                },
                new Entry(Math.Min(1,(this.ride?.Distance / Goals.Distance)  ?? 0))
                {
                    Color = GreenColor,
                    TextColor = GreenColor,
                    Label = "Distance",
                    ValueLabel = $"{(int)((this.ride?.Distance ?? 0) / 1000)}/{ (int)((this.Goals?.Distance ?? 0) / 1000)}",
                },
                new Entry((float)new Random().NextDouble())
                {
                    Color = PinkColor,
                    TextColor = PinkColor,
                    Label = "Heartbeat",
                },
                new Entry((float)new Random().NextDouble())
                {
                    Color = OrangeColor,
                    TextColor = OrangeColor,
                    Label = "Muscle",
                },
            },
            BackgroundColor = SKColors.Transparent,
        };

        private void Update()
        {
            this.ride = this.repository.Find(this.RideIdentifier);

            this.RaiseProperty(nameof(AltitudeChart));
            this.RaiseProperty(nameof(DistanceChart));
            this.RaiseProperty(nameof(EffortChart));
            this.RaiseProperty(nameof(GoalsChart));
            this.RaiseProperty(nameof(Points));           
        }

    }
}
