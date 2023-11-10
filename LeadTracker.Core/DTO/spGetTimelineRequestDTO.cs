using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class spGetTimelineRequestDTO
    {
        public int? RowsPerPage { get; set; }
        public int? PageIndex { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? WorkFlowStepId { get; set; }
        public int? AssignedTo { get; set; }
        public string? SearchTerm { get; set; }
    }
}
