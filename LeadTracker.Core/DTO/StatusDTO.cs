using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class StatusDTO
    {
        public IList<IFormFile>? Files { get; set; }

        public int? EnquiryId { get; set; }

        public int? TrackerId { get; set; }

        public int? ModuleType { get; set; }



        public DateTime? VisitExpectedDate { get; set; }

        public int? VisitedProjectId { get; set; }



        public string? Comment { get; set; }

        public int? WorkFlowId { get; set; }

        public int? CurrentWorkFlowStepId { get; set; }

        public int? NextWorkFlowStepId { get; set; }

        

    }
}
