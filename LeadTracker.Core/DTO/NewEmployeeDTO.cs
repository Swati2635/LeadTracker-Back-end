using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class NewEmployeeDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? EmailId { get; set; }

        public string? UserName { get; set; }

        public string? Mobile { get; set; }

        public int? ParentUserId { get; set; }

        public string? Gender { get; set; }

        public int? RoleId { get; set; }

    }
}
