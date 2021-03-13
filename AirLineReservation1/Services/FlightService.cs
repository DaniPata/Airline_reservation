using AirLineReservation1.Models;
using AirLineReservation1.Repository;
using AirLineReservation1.RepositoryWrapperr;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Services
{
    public class FlightService : IFlightService
    {

        private readonly IFlightRepository _flightRepository;
        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<bool> CreateFlight(Flight flight)
        {
            try
            {
                _flightRepository.Create(flight);
                await _flightRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        //public Flight GetFlight(string departure)
        //{
        //    IQueryable<Flight> flights = _flightRepository.FindByCondition(x => x.Departure == departure);
        //    Flight flight = new Flight();
        //    flight = flights.First();

        //    return flight;
        //}
        public IEnumerable<Flight> GetFlightByDeparture(string departure)
        {
            if (departure == null)
            {
                throw new Exception("Null string");
            }

            return _flightRepository.GetFlightByDeparture(departure);

        }

        public IEnumerable<Flight> GetFlightByArrival(string arrival)
        {
            if (arrival == null)
            {
                throw new Exception("Null string");
            }

            return _flightRepository.GetFlightByArrival(arrival);
        }

        public IEnumerable<Flight> GetFlightAccordingToFilters(string departure, string arrival, DateTime arrivalTime)
        {
            if (departure == null && arrival == null && arrivalTime == null)
            {
                throw new Exception("Null parameters");
            }

            return _flightRepository.GetFlightAccordingToFilters(departure, arrival, arrivalTime);
        }

        public IEnumerable<Flight> GetFlight()
        {
            return _flightRepository.GetFlight();
        }

        public async Task<bool> DeleteFlight(int id)
        {
            try
            {
                var flight = await GetFlightById(id);
                _flightRepository.Delete(flight);
                await _flightRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            IEnumerable<Flight> flights = _flightRepository.FindAll();

            return flights;
        }

        public Task<Flight> GetFlightById(int id)
        {
            try
            {
                return _flightRepository.FindByCondition(flight => flight.FlightId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> UpdateFlight(int id, Flight flight)
        {
            try
            {
                await GetFlightById(id);
                _flightRepository.Update(flight);
                await _flightRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool FlightExists(int id)
        {
            return _flightRepository.FindByCondition(e => e.FlightId == id).Any();
        }



    }
}
