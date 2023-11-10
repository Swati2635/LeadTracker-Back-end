using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;

public partial class Attendance : Identity
{
   

    public int? UserId { get; set; }

    public DateTime? LoginDate { get; set; }

    public string? LoginLatitude { get; set; }

    public string? LoginLongitude { get; set; }

    public DateTime? LogoutDate { get; set; }

    public string? LogoutLatitude { get; set; }

    public string? LogoutLongitude { get; set; }

    public bool? IsApproved { get; set; }

    public string? Status { get; set; }

    public int? ApprovedBy { get; set; }

   

    public virtual Employee? ApprovedByNavigation { get; set; }

    public virtual Employee? User { get; set; }
}
