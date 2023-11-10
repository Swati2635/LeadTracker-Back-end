using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.DTO
{
    public class spParentAndChildrenDTO
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public string RoleName { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
