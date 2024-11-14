using System;
using System.Collections.Generic;

namespace Gym_management_project.gym_management;

public partial class Classattendance
{
    public int Attendanceid { get; set; }

    public int Customerid { get; set; }

    public int Scheduleid { get; set; }

    public DateOnly Registered { get; set; }

    public DateOnly? Attended { get; set; }

    public virtual Classschedule Schedule { get; set; } = null!;
}
