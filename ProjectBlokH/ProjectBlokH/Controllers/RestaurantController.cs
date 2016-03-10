using ProjectBlokH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBlokH.Controllers
{
    public class RestaurantController : Controller
    {
        public void DeleteReservation(int id)
        {
            IApplicationRepository data = new ApplicationDeleteRepository();
            data.RemoveRestaurant(id);
        }
    }
}