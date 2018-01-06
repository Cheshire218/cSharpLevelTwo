using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployersAndDepartments
{
    public class CompanyStructure : INotifyPropertyChanged
    {
        HttpClient client = new HttpClient();
        public event PropertyChangedEventHandler PropertyChanged;

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


        public Dictionary<int, ObservableCollection<Employer>> companyStructure = new Dictionary<int, ObservableCollection<Employer>>();

        public CompanyStructure()
        {
            LoadDepartments();
        }


        /// <summary>
        /// Загружаем сотрудников из веб-сервиса
        /// </summary>
        /// <param name="depId"></param>
        public void ChangeDep(int depId)
        {
            DepartmentEmployers.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            string url = "http://localhost:60806/api/Department/"+depId;
            var result = client.GetStringAsync(url).Result;
            JArray empJSON = JArray.Parse(result);
            foreach (JObject emp in empJSON.Children<JObject>())
            {
                DepartmentEmployers.Add(new Employer(
                    Int32.Parse((string)emp.GetValue("Id")),
                    (string)emp.GetValue("LastName"),
                    (string)emp.GetValue("Name"),
                    (string)emp.GetValue("SecondName"),
                    Int32.Parse((string)emp.GetValue("Age")),
                    Int32.Parse((string)emp.GetValue("Salary")),
                    Int32.Parse((string)emp.GetValue("Dep"))
                    ));
            }
        }

        /// <summary>
        /// Загрузка подразделений из веб-сервиса
        /// </summary>
        private void LoadDepartments()
        {
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            string url = "http://localhost:60806/api/Department";
            var result = client.GetStringAsync(url).Result;
            JArray departmentsJSON = JArray.Parse(result);
            foreach (JObject dep in departmentsJSON.Children<JObject>())
            {
                departments.Add(new Department((string)dep.GetValue("Name"), Int32.Parse((string)dep.GetValue("Id"))));
            }
        }
    }
}
