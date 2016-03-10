using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProjectBlokH.Models;

namespace ProjectBlokH.Controllers
{
    [EnableCors(origins: "http://localhost:8000", headers: "*", methods: "*")]
    public class UserController : ApiController
    {

        [Route("api/users/{userId}/reservations")]
        public IEnumerable<ReservationRestaurant> getReservations(int userId)
        {
            IApplicationRepository data = new ApplicationReadRepository();
            return data.GetAllReservationsFromUser(userId);
        }

        public void DeleteUser(int id)
        {
            IApplicationRepository data = new ApplicationDeleteRepository();
            data.RemoveUser(id);
        }
    }
}
