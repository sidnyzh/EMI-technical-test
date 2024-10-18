using System;
using System.Collections.Generic;

namespace EMI.Domain.Entity;

public partial class PositionHistory
{
    public int PositionHistoryId { get; set; }

    public int Employee { get; set; }

    public int Position { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Employee EmployeeNavigation { get; set; } = null!;

    public virtual Position PositionNavigation { get; set; } = null!;
}
