using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebApplicationApi.Models
{
    public class Company
    {
        private SqlConnection sqlConn;

        public void GetData()
        {
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Company;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConn = new SqlConnection(cs);
            sqlConn.Open();
        }
    }
}