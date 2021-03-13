using AirLineReservation1.Database;
using AirLineReservation1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Repository.Sql
{
    public class RatingRepository : Repository<Rating>, IRatingRepository
    {
        public RatingRepository(AirLineContext AirLineContext)
            : base(AirLineContext)
        {
        }
    }
}

