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
    public class LoginController : ApiController
    {

        [HttpPost]
        public int postLogin([FromBody] User user)
        {
            if(user.Name !=null && user.Password !=null)
            {
                IApplicationRepository repo = new ApplicationReadRepository();
                return repo.login(user.Name, user.Password);

            }
            else
            {
                return -1;
            }
        }
    }
}
