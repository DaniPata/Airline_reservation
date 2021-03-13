using AirLineReservation1.Database;
using AirLineReservation1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Repository.Sql
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AirLineContext AirLineContext)
            : base(AirLineContext)
        {
        }
        public User GetUserById(string userId)
        {
            var user = AirLineContext.Users.Where(u => u.Id == userId).SingleOrDefault();
            return user;
        }
    }
}
