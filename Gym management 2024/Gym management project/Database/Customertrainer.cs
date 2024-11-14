using System;
using System.Collections.Generic;

namespace Gym_management_project.gym_management;

public partial class Customertrainer
{
    public int Id { get; set; }

    public int Customerid { get; set; }

    public int Trainerid { get; set; }

    public DateOnly Registered { get; set; }

    public DateTime? Attended { get; set; }
}
