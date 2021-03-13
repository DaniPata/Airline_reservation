using AirLineReservation1.Models;
using AirLineReservation1.RepositoryWrapperr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineReservation1.Services
{
    public class RatingService:IRatingService

    {
        private IRepositoryWrapper _repoWrapper;
        public RatingService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public void CreateRating(Rating rating)
        {
            _repoWrapper.Rating.Create(rating);
        }
        public void DeleteRating(Rating rating)
        {
            _repoWrapper.Rating.Delete(rating);
        }
    }
}
