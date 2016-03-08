using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectBlokH.Models
{
    public class Reservation
    {
        public int id { get; set; }
        public DateTime Date { get; set; }
        public Restaurant Restaurant { get; set; }
        public User User { get; set; }
    }
}