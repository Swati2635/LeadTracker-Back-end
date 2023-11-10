using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadTracker.API;

public partial class WorkFlowDetail : Identity
{
    public int? WorkFlowId { get; set; }

    public int? PreviousStep { get; set; }

    public int? CurrentStep { get; set; }

    public int? NextStep { get; set; }
    public int? OrgId { get; set; }
    public virtual Organisation? Org { get; set; }
    public virtual WorkFlow? WorkFlow { get; set; }
    [ForeignKey(nameof(CurrentStep))]
    public virtual WorkFlowStep? WorkFlowCurrentStep { get; set; }
    [ForeignKey(nameof(PreviousStep))]
    public virtual WorkFlowStep? WorkFlowPreviousStep { get; set; }
    [ForeignKey(nameof(NextStep))]
    public virtual WorkFlowStep? WorkFlowNextStep { get; set; }

    //public int? WorkFlowId { get; set; }

    //public int? PreviousStep { get; set; }

    //public int? CurrentStep { get; set; }

    //public int? NextStep { get; set; }

    //public int? OrgId { get; set; }

    //public virtual WorkFlowStep? CurrentStepNavigation { get; set; }

    //public virtual WorkFlowStep? NextStepNavigation { get; set; }

    //public virtual Organisation? Org { get; set; }

    //public virtual WorkFlowStep? PreviousStepNavigation { get; set; }

    //public virtual WorkFlow? WorkFlow { get; set; }
}
