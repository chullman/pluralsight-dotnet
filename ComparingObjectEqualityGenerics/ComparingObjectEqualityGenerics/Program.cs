using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingObjectEqualityGenerics
{
    public class EmployeeComparer : IEqualityComparer<Employee>, IComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return String.Equals(x.Name, y.Name);
        }

        public int GetHashCode(Employee obj)
        {
            return obj.Name.GetHashCode();
        }

        public int Compare(Employee x, Employee y)
        {
            return String.Compare(x.Name, y.Name);
        }
    }

    public class DepartmentsRepo : SortedDictionary<string, SortedSet<Employee>>
    {
        public DepartmentsRepo Add(string key, Employee employee)
        {
            if (!this.ContainsKey(key))
            {
                // Because we're new'ing up an employee each time, the sorted set will treat each employee as different objects even though they have the same name, so we need employeecomparer to check against the name property in the object for matching duplicates
                this.Add(key, new SortedSet<Employee>(new EmployeeComparer()));
            }

            this[key].Add(employee);
            return this; // allows us to chain adds together
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            //var departments = new SortedDictionary<string, SortedSet<Employee>>();
            var departments = new DepartmentsRepo();

            departments.Add("Sales", new Employee {Name = "Joy"})
                .Add("Sales", new Employee {Name = "Joy"})
                .Add("Sales", new Employee {Name = "Dani"})
                .Add("Sales", new Employee {Name = "Dani"});

            departments.Add("Engineering", new Employee {Name = "Scott"})
                .Add("Engineering", new Employee {Name = "Alex"})
                .Add("Engineering", new Employee {Name = "Dani"});

            foreach (var department in departments)
            {
                Console.WriteLine(department.Key);
                foreach (var employee in department.Value)
                {
                    Console.WriteLine("\t" + employee.Name);
                }
            }

        }
    }
}
