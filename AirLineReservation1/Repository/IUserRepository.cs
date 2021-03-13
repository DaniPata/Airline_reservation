using AirLineReservation1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserById(string userId);
    }
}
