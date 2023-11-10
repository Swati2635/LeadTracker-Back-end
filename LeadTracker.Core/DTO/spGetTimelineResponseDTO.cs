using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class spGetTimelineResponseDTO
    {
        public int TrackerId { get; set; }
        public int? EnquiryId { get; set; }
        public int? AssignedTo { get; set; }
        public int? WorkFlowId { get; set; }
        public int? WorkFlowStepId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsStepCompleted { get; set; }
        public int? OrgId { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmailId { get; set; }
        public string? UserName { get; set; }
        public int? RoleId { get; set; }
        public string? LeadSource { get; set; }
        public string? LeadSourceProject { get; set; }
        public string? LeadName { get; set; }
        public string? Requirement { get; set; }
        public decimal? Budget { get; set; }
        public int? DocumentId { get; set; }
        public string? DocLocation { get; set; }
        public string? StepName { get; set; }
        public long? RowNum { get; set; }


    }
}
