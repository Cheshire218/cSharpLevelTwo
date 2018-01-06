using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationApi.Models;

namespace WebApplicationApi.Controllers
{
    public class EmployerController : ApiController
    {
        GetData data = new GetData();
        

        // GET: api/Employer/5
        public Employer Get(int id)
        {
            return data.GetEmployer(id);
        }
    }
}
