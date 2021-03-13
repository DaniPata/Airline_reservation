using AirLineReservation1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.RepositoryWrapperr
{
    public interface IRepositoryWrapper
    {
      
        ICommentRepository Comment { get; }
        IContactRepository Contact { get; }
        IFlightRepository Flight { get; }
        IRatingRepository Rating { get; }
        IReservationRepository Reservation { get; }
        IUserRepository User { get; }

        void Save();
      

    }
}
