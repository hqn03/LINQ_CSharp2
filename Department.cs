using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_CSharp2
{
    class Department
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public static List<Department> getDepartments()
        {
            return new List<Department>(){
                new Department{ID=1,Name="IT" },
                new Department{ID=2,Name="HR" },
                new Department{ID=3,Name="Marketing"}
            };
        }
    }
}
