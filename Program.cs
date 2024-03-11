using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_CSharp2
{
    class Program
    {
        static void Main(string[] args)
        {

            var maxSalary = Employee.getEmployees().Max(x => x.Salary);
            var averageSalary = Employee.getEmployees().Average(x => x.Salary);
            Console.WriteLine("Max Salary = "+maxSalary);
            var minSalary = Employee.getEmployees().Min(x => x.Salary);
            Console.WriteLine("Min Salary = " + minSalary);
            Console.WriteLine("Average Salary = " + averageSalary);

            //Group join
            Console.WriteLine("\nGroup join");
            var employeesByDepartment = Department.getDepartments().GroupJoin(Employee.getEmployees(),
                                                    d => d.ID,
                                                    e => e.DepartmentID,
                                                    (deparment, employees) => new
                                                    {
                                                        Department = deparment,
                                                        Employees = employees
                                                    });
            foreach(var department in employeesByDepartment)
            {
                Console.WriteLine(department.Department.Name);
                foreach(var employee in department.Employees)
                {
                    Console.WriteLine(" "+employee.Name);
                }
                Console.WriteLine();
            }

            //Left Outer Join
            Console.WriteLine("\nLeft join");
            var result = from e in Employee.getEmployees()
                         join d in Department.getDepartments()
                         on e.DepartmentID equals d.ID into eGroup
                         from d in eGroup.DefaultIfEmpty()
                         select new
                         {
                             EmployeeName = e.Name,
                             DepartmentName = d == null ? "No Deparment" : d.Name
                         };

            foreach(var v in result)
                Console.WriteLine(v.EmployeeName+"\t"+v.DepartmentName);

            Console.WriteLine("\nRight Join");
            var result2 = from d in Department.getDepartments()
                          join e in Employee.getEmployees()
                          on d.ID equals e.DepartmentID into dGroup
                          from e in dGroup.DefaultIfEmpty()
                          select new
                          {
                              EmployeeName = e == null ? "No Employee" : e.Name,
                              DepartmentName = d.Name
                          };

            foreach (var v in result2)
                Console.WriteLine(v.EmployeeName + "\t" + v.DepartmentName);
            var maxAge = Employee.getEmployees().Max(x => Employee.getAge(x));
            var minAge = Employee.getEmployees().Min(x => Employee.getAge(x));
            Console.WriteLine();
            Console.WriteLine("Max Age = " + maxAge);
            Console.WriteLine("Min Age = " + minAge);
            Console.ReadKey();
        }
    }
}
