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
    public class UpdateController : ApiController
    {
        IApplicationRepository db;
        IApplicationRepository db2;

        [HttpPost]
        [Route("api/users/reservations/edit")]
        public IHttpActionResult PutReservation([FromBody] Reservation reservation)
        {
            db = new ApplicationUpdateRepository();

            db.UpdateReservation(reservation);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("api/users/reservations/edit")]
        public IEnumerable<Restaurant> GetRestaurants([FromBody] Reservation reservation)
        {
            db2 = new ApplicationReadRepository();

            return db2.GetAllRestaurants();
        }

        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != user.Id)
                return BadRequest();

            db.UpdateUser(user);

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult PutRestaurant(int id, Restaurant restaurant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != restaurant.Id)
                return BadRequest();

            db.UpdateRestaurant(restaurant);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
