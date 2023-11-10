using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class AttendanceDTO
    {
        public int AttendanceId { get; set; }

        public int? UserId { get; set; }

        public DateTime? LoginDate { get; set; }

        public string? LoginLatitude { get; set; }

        public string? LoginLongitude { get; set; }

        public DateTime? LogoutDate { get; set; }

        public string? LogoutLatitude { get; set; }

        public string? LogoutLongitude { get; set; }

        public bool? IsApproved { get; set; }

        public string? Status { get; set; }

        [ForeignKey("ApprovedBy")]
        public int? ApprovedBy { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }
    }
}