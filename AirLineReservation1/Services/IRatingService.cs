using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLineReservation1.Models;

namespace AirLineReservation1.Services
{
    interface IRatingService
    {
        void CreateRating(Rating rating);
        public void DeleteRating(Rating rating);
    }
}
