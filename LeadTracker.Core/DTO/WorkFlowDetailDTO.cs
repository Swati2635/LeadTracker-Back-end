using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class WorkFlowDetailDTO
    {
        public int WorkFlowDetailId { get; set; }

        public int? WorkFlowId { get; set; }

        public string? PreviousStep { get; set; }

        public string? CurrentStep { get; set; }

        public string? NextStep { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public int? OrgId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }
    }
}
