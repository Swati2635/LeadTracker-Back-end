using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class WorkFlowStepDTO
    {
        public int Id { get; set; }

        public int WorkFlowId { get; set; }

        public string StepName { get; set; } = null!;

        public int? OrgId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
