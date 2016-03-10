using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectBlokH.Models;
using System.Web.Http.Cors;

namespace ProjectBlokH.Controllers
{
    [EnableCors(origins: "http://localhost:8000", headers: "*", methods: "*")]
    public class ReservationController : ApiController
    {
        public IEnumerable<Reservation> getReservations()
        {
            IApplicationRepository data = new ApplicationReadRepository();
            return data.GetAllReservations();
        }

        [HttpPost]
        public void DeleteReservation([FromBody] int id)
        {
            IApplicationRepository data = new ApplicationDeleteRepository();
            data.RemoveReservation(id);
        }

    }
}
