using System;
using System.Collections.Generic;

namespace ORM_Database_First.Models
{
    public partial class DepartmentEmployee
    {
        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
        public virtual Project Project { get; set; } = null!;
    }
}
