using AirLineReservation1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Database
{
    public class AirLineContext : IdentityDbContext<User>
    {
        public AirLineContext(DbContextOptions<AirLineContext> options)
        : base(options)
        { }

  
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<User> User { get; set; }

       

    }
}
