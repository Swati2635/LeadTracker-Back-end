using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;


public partial class WorkFlowStep : Identity
{
    public int WorkFlowId { get; set; }

    public string StepName { get; set; } = null!;

    public int? OrgId { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<Lead> Leads { get; set; } = new List<Lead>();

    public virtual Organisation? Org { get; set; }

    public virtual ICollection<Tracker> Trackers { get; set; } = new List<Tracker>();

    public virtual WorkFlow WorkFlow { get; set; } = null!;


    //---------------------------------
    //public int WorkFlowId { get; set; }

    //public string StepName { get; set; } = null!;

    //public int? OrgId { get; set; }

    //public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    //public virtual ICollection<Lead> Leads { get; set; } = new List<Lead>();

    //public virtual Organisation? Org { get; set; }

    //public virtual ICollection<Tracker> Trackers { get; set; } = new List<Tracker>();

    //public virtual WorkFlow WorkFlow { get; set; } = null!;

    //public virtual ICollection<WorkFlowDetail> WorkFlowDetailCurrentStepNavigations { get; set; } = new List<WorkFlowDetail>();

    //public virtual ICollection<WorkFlowDetail> WorkFlowDetailNextStepNavigations { get; set; } = new List<WorkFlowDetail>();

    //public virtual ICollection<WorkFlowDetail> WorkFlowDetailPreviousStepNavigations { get; set; } = new List<WorkFlowDetail>();

}
