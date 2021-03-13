using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
    }
}
