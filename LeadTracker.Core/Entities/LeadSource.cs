using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;

public partial class LeadSource : Identity
{

    

    public DateTime? Date { get; set; }

    public string? LeadsSource { get; set; }

    public string? LeadSourceProject { get; set; }

    public string? Name { get; set; }

    public string? MobNo { get; set; }

    public string? EmailId { get; set; }

    public string? Requirement { get; set; }

    public decimal? Budget { get; set; }

    public string? Status { get; set; }

    public string? Remark { get; set; }

    public string? EnquiryType { get; set; }

    public int? TrakerId { get; set; }

    public bool? IsProcessed { get; set; }

}
