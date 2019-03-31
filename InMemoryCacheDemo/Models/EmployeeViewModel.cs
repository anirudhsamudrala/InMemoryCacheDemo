using System;
using System.Collections.Generic;

namespace InMemoryCacheDemo.Models
{
    public class EmployeeViewModel
    {
       public Employee emp { get; set; }
        public EmployeeViewModel()
        {
            this.emp = new Employee();
            emp.EmployeeName = "John Pete";

        }
    }

    public class Employee
    {

        public  string EmployeeName { get; set; }

    }

    public class CacheValueAndsource
    {
        public string EmployeeName { get; set; }
        public string Source { get; set; }
    }


}