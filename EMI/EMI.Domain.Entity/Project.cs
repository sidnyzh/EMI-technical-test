using System;
using System.Collections.Generic;

namespace EMI.Domain.Entity;

public partial class Project
{
    public int ProjectId { get; set; }

    public int Department { get; set; }

    public string Name { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Department DepartmentNavigation { get; set; } = null!;

    public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
}
