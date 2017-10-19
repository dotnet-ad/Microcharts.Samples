using System;
using System.Collections.Generic;

namespace Bikr
{
    public interface IRideRepository
    {
        IEnumerable<Ride> GetAll();

        Ride Find(int id);

        Ride GetGoals();
    }
}
