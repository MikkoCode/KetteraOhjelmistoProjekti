using System;
using System.Collections.Generic;

namespace Gym_management_project.gym_management;

public partial class Classschedule
{
    public int Scheduleid { get; set; }

    public int? Classid { get; set; }

    public int? Trainerid { get; set; }

    public DateOnly Starts { get; set; }

    public DateOnly Ends { get; set; }

    public virtual ICollection<Classattendance> Classattendances { get; set; } = new List<Classattendance>();
}
