using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public int FlightId { get; set; }
     
    }
}
