using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
    }
}
