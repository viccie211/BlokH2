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
         
        public UpdateController(IApplicationRepository db)
        {
            this.db = db;
        }

        public UpdateController()
        {
            db = new ApplicationUpdateRepository();
        }

        [HttpPost]
        [Route("api/users/reservations/edit")]
        public IEnumerable<Restaurant> PutReservation([FromBody] Reservation reservation)
        {
            db.UpdateReservation(reservation);

            return db.GetAllRestaurants();
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
