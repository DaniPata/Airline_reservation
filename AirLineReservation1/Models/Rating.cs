using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Models
{
    public class Rating
    {
        public int RatingId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public int Value { get; set; }
    }
}
