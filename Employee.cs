using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_CSharp2
{
    class Employee
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public int DepartmentID { set; get; }
        public double Salary { set; get; }
        public DateTime BirthDay { set; get; }
        public static int getAge(Employee employee)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - employee.BirthDay.Year;
            if (employee.BirthDay > today.AddYears(-age))
                age--;
            return age;
        }
        public static List<Employee> getEmployees()
        {
            return new List<Employee>(){
                new Employee{ID=1,Name="John",DepartmentID=1,Salary=1000,BirthDay= Convert.ToDateTime("1/1/2004")},
                new Employee{ID=2,Name="Michael",DepartmentID=2,Salary=1200,BirthDay= Convert.ToDateTime("1/1/2003")},
                new Employee{ID=3,Name="Anna",DepartmentID=3,Salary=1300,BirthDay= Convert.ToDateTime("1/1/2003")},
                new Employee{ID=4,Name="Emma",DepartmentID=1,Salary=1400,BirthDay= Convert.ToDateTime("1/1/2002")},
                new Employee{ID=5,Name="Etan",DepartmentID=2,Salary=1500,BirthDay= Convert.ToDateTime("1/1/2001")}
            };
        }
    }
}
