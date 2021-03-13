using AirLineReservation1.Database;
using AirLineReservation1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Repository.Sql
{
    public class FlightRepository : Repository<Flight>, IFlightRepository
    {
        public FlightRepository(AirLineContext AirLineContext)
            : base(AirLineContext)
        {

        }

            public IEnumerable<Flight> GetFlightByDeparture(string departure)
            {
                var flights = AirLineContext.Flight.Where(t => t.Departure == departure).AsEnumerable();
                return flights;
            }

           public IEnumerable<Flight> GetFlightByArrival(string arrival)
            {
                var flights = AirLineContext.Flight.Where(t => t.Arrival == arrival).AsEnumerable();
                return flights;
            }


            public IEnumerable<Flight> GetFlight()
            {
                var flights = AirLineContext.Flight.AsEnumerable();
                return flights;
            }

            public IEnumerable<Flight> GetFlightAccordingToFilters(string departure, string arrival, DateTime arrivalTime)
            {
                var flights = AirLineContext.Flight.Where(t => t.Departure == departure && t.Arrival == arrival
                                                                            && t.ArrivalTime.Date >= arrivalTime.Date).AsEnumerable();
                return flights;
            }
        }


    }

