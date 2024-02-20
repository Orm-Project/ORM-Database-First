using System;
using System.Collections.Generic;

namespace ORM_Database_First.Models
{
    public partial class Employee
    {
        public Employee()
        {
            DepartmentEmployees = new HashSet<DepartmentEmployee>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public int? ProjectId { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
        public virtual Project? Project { get; set; }
        public virtual ICollection<DepartmentEmployee> DepartmentEmployees { get; set; }
    }
}
