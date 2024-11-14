using System;
using System.Collections.Generic;

namespace Gym_management_project.gym_management;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Lastname { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }
}
