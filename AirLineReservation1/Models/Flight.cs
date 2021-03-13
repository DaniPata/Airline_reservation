using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string Name { get; set; }
        public string Aircraft { get; set; }
        public DateTime Date { get; set; }
        public string Departure { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Arrival { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Class { get; set; }
        public int Capacity { get; set; }
        public double Price { get; set; }
        public int RemainSeats { get; set; }

    }
}
