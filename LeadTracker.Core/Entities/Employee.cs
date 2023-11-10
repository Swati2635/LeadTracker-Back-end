using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;


public partial class Employee : Identity
{


    public string? Name { get; set; }

    public string? EmailId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Mpin { get; set; }

    public string? Mobile { get; set; }

    public int? ParentUserId { get; set; }

   

    public int? OrgId { get; set; }

    public string? Gender { get; set; }

    public int? RoleId { get; set; }

    public byte[]? Photo { get; set; }

    public string? DeviceId { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<Lead> Leads { get; set; } = new List<Lead>();

    public virtual ICollection<Attendance> AttendanceApprovedByNavigations { get; set; } = new List<Attendance>();

    public virtual ICollection<Attendance> AttendanceUsers { get; set; } = new List<Attendance>();

    public virtual Organisation? Org { get; set; }

    public virtual Role? Role { get; set; }

    public virtual ICollection<UserLocation> UserLocations { get; set; } = new List<UserLocation>();


}


