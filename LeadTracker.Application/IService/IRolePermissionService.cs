﻿using LeadTracker.API;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface IRolePermissionService
    {
        Task CreateRolePermission(RolePermissionDTO rolePermisson);

        Task<RolePermissionDTO> GetRolePermissionByIdAsync(int id);

        Task<IEnumerable<RolePermissionDTO>> GetAllRolePermissionAsync();

        Task UpdateRolePermissionAsync(int id, RolePermissionDTO rolePermission);

        Task DeleteRolePermissionAsync(int id);
    }
}
