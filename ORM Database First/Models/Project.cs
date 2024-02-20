using System;
using System.Collections.Generic;

namespace ORM_Database_First.Models
{
    public partial class Project
    {
        public Project()
        {
            DepartmentEmployees = new HashSet<DepartmentEmployee>();
            Employees = new HashSet<Employee>();
        }

        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
        public virtual ICollection<DepartmentEmployee> DepartmentEmployees { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
