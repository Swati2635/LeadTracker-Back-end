using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class LeadSourceDTO
    {
        public int EnquiryId { get; set; }

        public DateTime? Date { get; set; }

        public string? LeadSource1 { get; set; }

        public string? LeadSourceProject { get; set; }

        public string? Name { get; set; }

        public string? MobNo { get; set; }

        public string? EmailId { get; set; }

        public string? Requirement { get; set; }

        public decimal? Budget { get; set; }

        public string? Description { get; set; }

        public string? Status { get; set; }

        public string? FinalRemark { get; set; }

        public string? EnquiryType { get; set; }

        public int? TrakerFlowId { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
