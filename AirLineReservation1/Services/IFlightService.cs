using AirLineReservation1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Services
{
     public interface IFlightService
    {
        public IEnumerable<Flight> GetAllFlights();
        public Task<Flight> GetFlightById(int id);
        public Task<bool> UpdateFlight(int id, Flight flight);
        public Task<bool> CreateFlight(Flight flight);
        public Task<bool> DeleteFlight(int id);
        public bool FlightExists(int id);
        public IEnumerable<Flight> GetFlightByDeparture(string departure);
        public IEnumerable<Flight> GetFlightByArrival(string arrival);
        public IEnumerable<Flight> GetFlightAccordingToFilters(string departure, string arrival, DateTime arrivalTime);
        public IEnumerable<Flight> GetFlight();

    }
}
