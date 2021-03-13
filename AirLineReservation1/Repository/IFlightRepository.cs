using AirLineReservation1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Repository
{
    public interface IFlightRepository : IRepository<Flight>
    {


        IEnumerable<Flight> GetFlightByDeparture(string departure);
        IEnumerable<Flight> GetFlightByArrival(string arrival);

        IEnumerable<Flight> GetFlightAccordingToFilters(string departure, string arrival, DateTime arrivalTime);
        IEnumerable<Flight> GetFlight();
    }
}
