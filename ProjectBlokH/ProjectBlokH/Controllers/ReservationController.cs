﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
<<<<<<< .merge_file_a16536
=======
using ProjectBlokH.Models;
>>>>>>> .merge_file_a16528

namespace ProjectBlokH.Controllers
{
    public class ReservationController : ApiController
    {
<<<<<<< .merge_file_a16536

=======
        public IEnumerable<Reservation> getReservations()
        {
            IApplicationRepository data = new ApplicationReadRepository();
            return data.GetAllReservations();
        }
>>>>>>> .merge_file_a16528
    }
}
