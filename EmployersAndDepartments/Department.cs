﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployersAndDepartments
{
    /// <summary>
    /// Класс подразделения
    /// </summary>
    public class Department
    {
        //static int count=0;

        public string Name { get; set; }
        public int Id { get; set; }

        public Department(string name, int id)
        {
            Name = name;
            //Id = count++;
            Id = id;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
