using System;
namespace School
{
    public abstract class Employee
    {
        protected string Name { get; set; }
        protected int EmployeeNr { get; set; }

        public Employee(string name, int enr)
        {
            this.Name = name;
            EmployeeNr = enr;
        }

        public Employee()
        {
        }

        public abstract void checkCredentials();
        
    }
}
