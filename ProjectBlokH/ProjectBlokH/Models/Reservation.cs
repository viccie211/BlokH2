using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectshizzleblokh.Models
{
    public class Reservation
    {
        public DateTime Date { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}