using AirLineReservation1.Models;
using AirLineReservation1.RepositoryWrapperr;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repoWrapper;
        public UserService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public IEnumerable<User> GetAllUsers()
        {
            IEnumerable<User> users = _repoWrapper.User.FindAll();

            return users;
        }

        public User GetUser(string userID)
        {
            IQueryable<User> users = _repoWrapper.User.FindByCondition(x => x.Id == userID);
            User user = new User();
            user = users.First();

            return user;
        }

        public void CreateUser(User user)
        {
            _repoWrapper.User.Create(user);
        }

    }
}
