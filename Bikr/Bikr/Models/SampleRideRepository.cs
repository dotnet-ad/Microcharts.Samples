namespace Bikr
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SampleRideRepository : IRideRepository
    {
        public SampleRideRepository()
        {
            var date = DateTime.Now;
            this.rides = Enumerable.Range(0, random.Next(10, 20)).Select(x => GenerateRide(x+1,"Place" + x, date = date.AddHours(- random.Next(24, 128)))).ToArray();
        }

        private IEnumerable<Ride> rides;

        private static Random random = new Random();

        private static Ride GenerateRide(int id, string name, DateTime date)
        {
            var time = TimeSpan.Zero;
            var altitude = random.Next(-50, 100);
            var distance = 0.0f;
            var points = Enumerable.Range(0, random.Next(40, 80)).Select(x => new RidePoint(random.Next(), random.Next(), altitude += random.Next(-10, 10), time += TimeSpan.FromMinutes(random.Next(1, 2)), distance += random.Next(400, 500)));
            return new Ride(id, name, date, points);
        }

    
        public IEnumerable<Ride> GetAll() => rides.OrderByDescending(x => x.Date);

        public Ride Find(int id) => rides.FirstOrDefault(x => x.Identifier == id);

        public Ride GetGoals() => new Ride(0, "Goals", DateTime.Now, new []
        {
            new RidePoint(0,0, 2000, TimeSpan.FromHours(1.5f), 60000),
        });
    }
}
