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

        // POST: api/Department
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Department/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Department/5
        public void Delete(int id)
        {
        }
    }
}
