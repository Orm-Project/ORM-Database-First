using System;
using System.Collections.Generic;

namespace ORM_Database_First.Models
{
    public partial class Department
    {
        public Department()
        {
            DepartmentEmployees = new HashSet<DepartmentEmployee>();
            Employees = new HashSet<Employee>();
            Projects = new HashSet<Project>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; } = null!;

        public virtual Manager Manager { get; set; } = null!;
        public virtual ICollection<DepartmentEmployee> DepartmentEmployees { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
