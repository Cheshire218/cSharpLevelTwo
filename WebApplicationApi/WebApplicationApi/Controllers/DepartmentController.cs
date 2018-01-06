using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationApi.Models;

namespace WebApplicationApi.Controllers
{
    public class DepartmentController : ApiController
    {
        GetData data = new GetData();

        // GET: api/Department
        public List<Department> Get()
        {
            return data.GetDepartments();
        }

        // GET: api/Department/5
        public List<Employer> Get(int id)
        {
            return data.GetDepartmentEmployers(id);
        }
    }
}
