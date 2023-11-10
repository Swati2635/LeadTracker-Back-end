using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;

public partial class WorkFlow : Identity
{

   

    public string? WorkFlowName { get; set; }

   

    public int? OrgId { get; set; }

   

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual Organisation? Org { get; set; }

    public virtual ICollection<Tracker> Trackers { get; set; } = new List<Tracker>();

    public virtual ICollection<WorkFlowDetail> WorkFlowDetails { get; set; } = new List<WorkFlowDetail>();

    public virtual ICollection<WorkFlowStep> WorkFlowSteps { get; set; } = new List<WorkFlowStep>();

  

}

