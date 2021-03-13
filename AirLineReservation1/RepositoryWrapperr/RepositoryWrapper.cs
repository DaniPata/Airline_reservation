using AirLineReservation1.Database;
using AirLineReservation1.Repository;
using AirLineReservation1.Repository.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.RepositoryWrapperr
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AirLineContext _airliningContext;
   
        private ICommentRepository _comment;
        private IContactRepository _contact;
        private IFlightRepository _flight;
        private IRatingRepository _rating;
        private IReservationRepository _reservation;
        private IUserRepository _user;


        public ICommentRepository Comment
        {
            get
            {
                if (_comment == null)
                {
                    _comment = new CommentRepository(_airliningContext);
                }

                return _comment;
            }
        }
        public IContactRepository Contact
        {
            get
            {
                if (_contact == null)
                {
                    _contact = new ContactRepository(_airliningContext);
                }

                return _contact;
            }
        }

        public IFlightRepository Flight
        {
            get
            {
                if (_flight == null)
                {
                    _flight = new FlightRepository(_airliningContext);
                }

                return _flight;
            }
        }
        public IRatingRepository Rating
        {
            get
            {
                if (_rating == null)
                {
                    _rating = new RatingRepository(_airliningContext);
                }

                return _rating;
            }
        }

        public IReservationRepository Reservation
        {
            get
            {
                if (_reservation == null)
                {
                    _reservation = new ReservationRepository(_airliningContext);
                }

                return _reservation;
            }
        }
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_airliningContext);
                }

                return _user;
            }
        }

        public RepositoryWrapper(AirLineContext airliningContext)
        {
            _airliningContext = airliningContext;
        }

        public void Save()
        {
            _airliningContext.SaveChanges();
        }

     

    }
}
