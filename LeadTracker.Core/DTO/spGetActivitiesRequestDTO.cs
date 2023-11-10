using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class spGetActivitiesRequestDTO
    {
        public int? RowsPerPage { get; set; }
        public int? PageIndex { get; set; }
        public int? WorkFlowId { get; set; }
        public int? WorkFlowStepId { get; set; }
        public int? AssignedTo { get; set; }
        public DateTime? ExpectedFromDate { get; set; }
        public DateTime? ExpectedToDate { get; set; }
        public string? SearchTerm { get; set; }
    }
}
