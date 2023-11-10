using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class LeadSourceGetDTO
    {
        public int Id { get; set; }

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

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public bool? IsProcessed { get; set; }
    }
}
