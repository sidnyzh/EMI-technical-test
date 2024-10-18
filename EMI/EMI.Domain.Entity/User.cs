using System;
using System.Collections.Generic;

namespace EMI.Domain.Entity;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Name { get; set; }

    public string Role { get; set; } = null!;
}
