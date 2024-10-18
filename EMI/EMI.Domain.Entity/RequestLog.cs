using System;
using System.Collections.Generic;

namespace EMI.Domain.Entity;

public partial class RequestLog
{
    public int Id { get; set; }

    public DateTime Timestamp { get; set; }

    public string RequestMethod { get; set; } = null!;

    public string RequestPath { get; set; } = null!;

    public string? QueryString { get; set; }

    public string? RequestBody { get; set; }

    public string? Headers { get; set; }

    public string? Email { get; set; }

    public string? Identifier { get; set; }
}
