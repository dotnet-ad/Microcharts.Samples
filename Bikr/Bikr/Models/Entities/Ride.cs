namespace Bikr
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Ride
    {
        public Ride(int id, string place, DateTime date, IEnumerable<RidePoint> points)
        {
            this.Points = points.ToArray();

            this.Identifier = id;
            this.Location = place;
            this.Distance = points.Max(x => x.Distance);
            this.Date = date;
            this.TotalTime = points.Max(x => x.Time);
            this.AverageSpeed = (float)(this.Distance / (1000 * this.TotalTime.TotalHours));
            this.Calories = CalculateCalories(points);


            var up = 0.0f;
            var down = 0.0f;
            var previousAltitude = 0.0f;

            foreach (var point in points)
            {
                if (previousAltitude < point.Altitude)
                    up += point.Altitude - previousAltitude;
                else if (previousAltitude > point.Altitude)
                    down += previousAltitude - point.Altitude;
                previousAltitude = point.Altitude;
            }

            this.TotalUp = up;
            this.TotalDown = down;

        }

        public int Identifier { get; }

        public float Distance { get; }

        public float Calories { get; }

        public float AverageSpeed { get; }

        public DateTime Date { get; }

        public float TotalUp { get; }

        public float TotalDown { get; }

        public TimeSpan TotalTime { get; }

        public string Location { get; }

        public IEnumerable<RidePoint> Points { get; }

        /// <summary>
        /// Completely fake calculation for demonstration purpose.
        /// </summary>
        /// <returns>The calories.</returns>
        /// <param name="points">Points.</param>
        private static float CalculateCalories(IEnumerable<RidePoint> points)
        {
            var result = 0.0f;

            var altitude = 0.0f;
            var distance = 0.0f;

            foreach (var point in points)
            {
                result += (point.Distance - distance) + (point.Altitude - altitude);
                distance = point.Distance;
                altitude = point.Altitude;
            }

            return result / 40;
        }
    }
}
