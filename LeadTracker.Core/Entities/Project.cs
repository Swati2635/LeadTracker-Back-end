using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;

public partial class Project : Identity
{
  

    public string? ProjectName { get; set; }

    public int? LocationId { get; set; }

    public string? Address { get; set; }

    public string? BuilderName { get; set; }

   

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Location? Location { get; set; }

    public virtual ICollection<ProjectDetail> ProjectDetails { get; set; } = new List<ProjectDetail>();

    public virtual ICollection<Tracker> Trackers { get; set; } = new List<Tracker>();
}
