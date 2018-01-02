using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployersAndDepartments
{
    public class CompanyStructure : INotifyPropertyChanged
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployersAndDepartments;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        public event PropertyChangedEventHandler PropertyChanged;

        #region подразделение;
        /// <summary>
        /// Подразделения теперь берутся из свойства Departments
        /// </summary>
        public ObservableCollection<Department> Departments
        {
            get => this.departments;
            set
            {
                this.departments = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Departments)));
            }
        }
        private ObservableCollection<Department> departments = new ObservableCollection<Department>();
        #endregion;

        #region сотрудники выбранного подразделения;
        /// <summary>
        /// Сотрудники теперь берутся из свойства DepartmentEmployers
        /// </summary>
        public ObservableCollection<Employer> DepartmentEmployers
        {
            get => this.depEmployers;
            set
            {
                this.depEmployers = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.DepartmentEmployers)));
            }
        }
        private ObservableCollection<Employer> depEmployers = new ObservableCollection<Employer>();
        #endregion;

        /// <summary>
        /// Список всех сотрудников
        /// </summary>
        private List<Employer> employers = new List<Employer>();

        #region Словарь подразделений и сотрудников
        public Dictionary<int, ObservableCollection<Employer>> companyStructure = new Dictionary<int, ObservableCollection<Employer>>();

        public CompanyStructure()
        {
            LoadData();
            GetStructure();
        }

        public void GetStructure()
        {
            foreach (Department dep in departments)
            {
                companyStructure.Add(dep.Id, new ObservableCollection<Employer>());
            }
            foreach (Employer emp in employers)
            {
                if (companyStructure.ContainsKey(emp.Dep))
                {
                    companyStructure[emp.Dep].Add(emp);
                }
                else
                {
                    companyStructure.Add(emp.Dep, new ObservableCollection<Employer>() { emp });
                }
            }
        }
        #endregion;

        /// <summary>
        /// Изменяем источник данных для списка сотрудников выбранного подразделения
        /// </summary>
        /// <param name="depId"></param>
        public void ChangeDep(int depId)
        {
            DepartmentEmployers = companyStructure[depId];
        }

        #region "Загрузка данных из файлов"
        private void LoadData()
        {
            LoadDepartments();
            LoadEmployers();
        }

        private void LoadDepartments()
        {
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter();
            
            using (connection)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT id, name FROM Departments", connection);
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        departments.Add(new Department(name, id));
                    }
                }
            }

                //try
                //{
                //    using (StreamReader sr = new StreamReader("DepartmentsData.db"))
                //    {
                //        while (!sr.EndOfStream)
                //        {
                //            string name = sr.ReadLine();
                //            sr.ReadLine();
                //            departments.Add(new Department(name));
                //        }
                //    }
                //}
                //catch (Exception)
                //{
                //    Console.WriteLine("Нет БД");
                //}
        }

        private void LoadEmployers()
        {
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter();

            using (connection)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT Id, name, lastName, secondName, age, salary, depId FROM Emp", connection);
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string lastName = reader.GetString(1);
                        string secondName = reader.GetString(1);
                        int age = reader.GetInt32(0);
                        int salary = reader.GetInt32(0);
                        int depId = reader.GetInt32(0);
                        employers.Add(new Employer(lastName, name, secondName, age, salary, depId));
                    }
                }
            }
            //try
            //{
            //    using (StreamReader sr = new StreamReader("EmployersData.db"))
            //    {
            //        while (!sr.EndOfStream)
            //        {
            //            string lastName = sr.ReadLine();
            //            string name = sr.ReadLine();
            //            string secondName = sr.ReadLine();
            //            int age = Int32.Parse(sr.ReadLine());
            //            int salary = Int32.Parse(sr.ReadLine());
            //            int dep = Int32.Parse(sr.ReadLine());
            //            sr.ReadLine();
            //            employers.Add(new Employer(lastName, name, secondName, age, salary, dep));
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Нет БД");
            //}
        }
        #endregion;

        #region "Сохранение данных";
        private void SaveDepartments()
        {
            //using (StreamWriter sw = new StreamWriter("DepartmentsData.db"))
            //{
            //    foreach (Department dep in departments)
            //    {
            //        sw.WriteLine(dep.Name);
            //        sw.WriteLine();
            //    }
            //}
        }

        private void SaveEmployers()
        {
            //using (StreamWriter sw = new StreamWriter("EmployersData.db"))
            //{
            //    foreach (Employer emp in employers)
            //    {
            //        sw.WriteLine(emp.LastName);
            //        sw.WriteLine(emp.Name);
            //        sw.WriteLine(emp.SecondName);
            //        sw.WriteLine(emp.Age);
            //        sw.WriteLine(emp.Salary);
            //        sw.WriteLine(emp.Dep);
            //        sw.WriteLine();
            //    }
            //}
        }

        public void SaveData()
        {
            SaveDepartments();
            SaveEmployers();
        }
        #endregion;
    }
}
