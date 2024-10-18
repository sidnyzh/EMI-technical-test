using System;
using System.Collections.Generic;

namespace EMI.Domain.Entity;

public partial class EmployeeProject
{
    public int EmployeeProjectId { get; set; }

    public int Employee { get; set; }

    public int Project { get; set; }

    public virtual Employee EmployeeNavigation { get; set; } = null!;

    public virtual Project ProjectNavigation { get; set; } = null!;
}
