using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }

        public string? ProjectName { get; set; }

        public int? LocationId { get; set; }

        public string? Address { get; set; }

        public string? BuilderName { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        
    }
}
