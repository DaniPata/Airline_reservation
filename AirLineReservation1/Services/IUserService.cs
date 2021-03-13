using AirLineReservation1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        void CreateUser(User user);
        User GetUser(string userID);
    }
}
