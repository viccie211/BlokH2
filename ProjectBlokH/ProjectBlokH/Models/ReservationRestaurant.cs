using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectBlokH.Models
{
    public class ReservationRestaurant
    {
        public Reservation reserv { get; set; }
        public Restaurant rest { get; set; }
    }
}