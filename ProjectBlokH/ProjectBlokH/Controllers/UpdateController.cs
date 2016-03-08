using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectBlokH.Models;

namespace ProjectBlokH.Controllers
{
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

        public IHttpActionResult PutReservation(int id, Reservation reservation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != reservation.id)
                return BadRequest();

            db.UpdateReservation(reservation);

            return StatusCode(HttpStatusCode.NoContent);
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

        public IHttpActionResult PutProduct(int id, Restaurant restaurant)
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
