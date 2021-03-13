using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.DTO.Request
{
    public class ContactRequest
    {
        public string Subject { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }
    }
}
