using System;
using System.Collections.Generic;

namespace Gym_management_project.gym_management;

public partial class Membership
{
    public int Membershipid { get; set; }

    public int Customerid { get; set; }

    public int Productid { get; set; }

    public float Price { get; set; }

    public DateOnly Startdate { get; set; }

    public DateOnly Enddate { get; set; }
}
