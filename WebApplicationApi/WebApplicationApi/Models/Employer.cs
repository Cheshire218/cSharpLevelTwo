using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationApi.Models
{
    public class Employer
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int Dep { get; set; }
    }
}