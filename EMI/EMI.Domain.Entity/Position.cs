using System;
using System.Collections.Generic;

namespace EMI.Domain.Entity;

public partial class Position
{
    public int PositionId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<PositionHistory> PositionHistories { get; set; } = new List<PositionHistory>();
}
