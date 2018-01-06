using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebApplicationApi.Models
{
    public class GetData
    {
        private SqlConnection sqlConn;

        public GetData()
        {
            string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Company;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConn = new SqlConnection(cs);
            sqlConn.Open();
        }

        ~GetData()
        {
            sqlConn.Close();
        }

        public List<Department> GetDepartments()
        {
            string sql = @"SELECT * FROM Departments";
            List<Department> list = new List<Department>();

            using (var com = new SqlCommand(sql, sqlConn))
            {
                using (SqlDataReader sdr = com.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        list.Add(new Department
                        {

                            Id = Int32.Parse(sdr[0].ToString()),
                            Name = sdr[1].ToString()
                        });

                    }
                }
                com.ExecuteNonQuery();
            }
            return list;
        }

        public List<Employer> GetDepartmentEmployers(int depId)
        {
            string sql = @"SELECT * FROM Emp WHERE depId = "+depId;
            List<Employer> list = new List<Employer>();

            using (var com = new SqlCommand(sql, sqlConn))
            {
                using (SqlDataReader sdr = com.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        list.Add(new Employer
                        {
                            Id = Int32.Parse(sdr[0].ToString()),
                            LastName = sdr[2].ToString(),
                            Name = sdr[1].ToString(),
                            SecondName = sdr[3].ToString(),
                            Age = Int32.Parse(sdr[4].ToString()),
                            Salary = Int32.Parse(sdr[5].ToString()),
                            Dep = Int32.Parse(sdr[6].ToString())
                        });

                    }
                }
                com.ExecuteNonQuery();
            }
            return list;
        }

        public Employer GetEmployer(int empId)
        {
            string sql = @"SELECT * FROM Emp WHERE Id = " + empId;
            List<Employer> list = new List<Employer>();

            using (var com = new SqlCommand(sql, sqlConn))
            {
                using (SqlDataReader sdr = com.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        list.Add(new Employer
                        {
                            Id = Int32.Parse(sdr[0].ToString()),
                            LastName = sdr[2].ToString(),
                            Name = sdr[1].ToString(),
                            SecondName = sdr[3].ToString(),
                            Age = Int32.Parse(sdr[4].ToString()),
                            Salary = Int32.Parse(sdr[5].ToString()),
                            Dep = Int32.Parse(sdr[6].ToString())
                        });

                    }
                }
                com.ExecuteNonQuery();
            }
            if (list.Count > 0)
            {
                return list[0];
            } else
            {
                return null;
            }
        }

    }
}