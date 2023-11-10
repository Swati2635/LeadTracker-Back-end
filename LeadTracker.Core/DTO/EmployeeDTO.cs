using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? EmailId { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? Mpin { get; set; }

        public string? Mobile { get; set; }

        public int? ParentUserId { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? OrgId { get; set; }

        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public string? Gender { get; set; }

        public int? RoleId { get; set; }

        public byte[]? Photo { get; set; }

        public string? DeviceId { get; set; }
    }
}
