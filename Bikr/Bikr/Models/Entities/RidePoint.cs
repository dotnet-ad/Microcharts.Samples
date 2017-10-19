namespace Bikr
{
    using System;

    public class RidePoint
    {
        public RidePoint(float latitude, float longitude, float altitude, TimeSpan time, float distance)
        {
            this.Latitude = latitude;
            this.Longitude = Longitude;
            this.Altitude = altitude;
            this.Time = time;
            this.Distance = distance;
        }

        public float Latitude { get; }

        public float Longitude { get; }

        public float Altitude { get; }

        public TimeSpan Time { get; }

        public float Distance { get; }
    }
}
