using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;

namespace LeadTracker.API;

public partial class Role : Identity
{
  

    public string? Name { get; set; }

   

    public int? OrgId { get; set; }

    public int? ParentRoleId { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Organisation? Org { get; set; }

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
