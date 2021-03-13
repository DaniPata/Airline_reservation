using AirLineReservation1.Database;
using AirLineReservation1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Repository.Sql
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(AirLineContext AirLineContext)
            : base(AirLineContext)
        {
        }
    }
}
