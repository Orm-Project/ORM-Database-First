using System;
using System.Collections.Generic;

namespace ORM_Database_First.Models
{
    public partial class Manager
    {
        public int ManagerId { get; set; }
        public string? ManagerName { get; set; }

        public virtual Department ManagerNavigation { get; set; } = null!;
    }
}
