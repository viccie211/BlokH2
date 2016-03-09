using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectBlokH.Models;

namespace ProjectBlokH.Controllers
{
    public class ReservationController : ApiController
    {
        public IEnumerable<Reservation> getReservations()
        {
            IApplicationRepository data = new ApplicationReadRepository();
            return data.GetAllReservations();
        }

        public Reservation PostReservation(Reservation res)
        {
            IApplicationRepository data = new ApplicationReadRepository();
            return data.AddReservation(res);
        }
    }
}
