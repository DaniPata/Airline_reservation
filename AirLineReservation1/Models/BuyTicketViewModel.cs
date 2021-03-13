using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Models
{
    public class BuyTicketViewModel
    {
        public Guid FlightId { get; set; }
        public int SeatNumber { get; set; }
    }
}
