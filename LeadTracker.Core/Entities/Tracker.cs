using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadTracker.API;

public partial class Tracker : Identity
{
    //public int? EnquiryId { get; set; }
    //public int? CodeId { get; set; }
    //public string? Remark { get; set; }
    //public DateTime? Date { get; set; }
    //public bool? VisitExpected { get; set; }
    //public DateTime? VisitExpectedDate { get; set; }
    //public int? VisitedProjectId { get; set; }
    //public string? VisitRemark { get; set; }
    //public int? AssignedTo { get; set; }

    //[ForeignKey(nameof(AssignedTo))]
    //public Employee? Employee { get; set; }

    //public int? WorkFlowId { get; set; }
    //[ForeignKey(nameof(WorkFlowId))]
    //public WorkFlow? WorkFlow { get; set; }

    //public int? WorkFlowStepId { get; set; }
    //[ForeignKey(nameof(WorkFlowStepId))]
    //public WorkFlowStep? WorkFlowStep { get; set; }

    // // // // // 


    //public int? EnquiryId { get; set; }

    //public int? CodeId { get; set; }

    //public string? Remark { get; set; }

    //public DateTime? Date { get; set; }

    //public bool? VisitExpected { get; set; }

    //public DateTime? VisitExpectedDate { get; set; }

    //public int? VisitedProjectId { get; set; }

    //public string? VisitRemark { get; set; }

    //public int? AssignedTo { get; set; }

    //public int? WorkFlowId { get; set; }

    //public int? WorkFlowStepId { get; set; }
    //public virtual WorkFlow? WorkFlow { get; set; }

    //public virtual WorkFlowStep? WorkFlowStep { get; set; }

    //[ForeignKey("EnquiryId")]
    //public virtual Lead? Enquiry { get; set; }

    //public bool? IsStepCompleted { get; set; }

    ////


    public int? EnquiryId { get; set; }

    public int? CodeId { get; set; }

    public string? Remark { get; set; }

    public DateTime? Date { get; set; }

    public bool? VisitExpected { get; set; }

    public DateTime? VisitExpectedDate { get; set; }

    public int? VisitedProjectId { get; set; }

    public string? VisitRemark { get; set; }

  
    public int? AssignedTo { get; set; }

    public int? WorkFlowId { get; set; }

    public int? WorkFlowStepId { get; set; }

  

    public bool? IsStepCompleted { get; set; }

   

    public int? OrgId { get; set; }

    [ForeignKey("EnquiryId")]
    public virtual Lead? Enquiry { get; set; }

    public virtual Organisation? Org { get; set; }

    public virtual WorkFlow? WorkFlow { get; set; }

    public virtual WorkFlowStep? WorkFlowStep { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

   

    public virtual Project? VisitedProject { get; set; }

    
}
