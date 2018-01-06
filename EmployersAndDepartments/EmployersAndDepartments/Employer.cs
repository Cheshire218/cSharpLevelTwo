using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployersAndDepartments
{
    /// <summary>
    /// Класс сотрудника
    /// </summary>
    public class Employer
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int Dep { get; set; }


        public Employer(int id, string lastName, string name, string secondName, int age, int salary, int dep)
        {
            Id = id;
            LastName = lastName;
            Name = name;
            SecondName = secondName;
            Age = age;
            Salary = salary;
            Dep = dep;
        }

        public override string ToString()
        {
            return $"{LastName} {Name} {SecondName}";
        }
    }
}
