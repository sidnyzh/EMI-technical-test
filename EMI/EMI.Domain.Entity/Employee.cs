using System;
using System.Collections.Generic;

namespace EMI.Domain.Entity;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public int Department { get; set; }

    public string Name { get; set; } = null!;

    public int CurrentPosition { get; set; }

    public decimal Salary { get; set; }

    public virtual Position CurrentPositionNavigation { get; set; } = null!;

    public virtual Department DepartmentNavigation { get; set; } = null!;

    public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();

    public virtual ICollection<PositionHistory> PositionHistories { get; set; } = new List<PositionHistory>();
}
