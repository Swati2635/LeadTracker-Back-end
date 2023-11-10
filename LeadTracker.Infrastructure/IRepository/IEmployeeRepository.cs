using LeadTracker.API;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.IRepository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> GetUserLoginAsync(string mobile, string password);

        List<spParentAndChildrenDTO> GetEmployeesByUserIdAsync(int userId, int orgId);

        Task<bool> ChangePasswordAsync(string username, string currentPassword, string newPassword);

        Task UpdateEmployeeDeviceIdAsync(int employeeId, string deviceId);

        List<spParentDTO> GetspParentOfUsersByOrgIdAsync();

        List<spGetActivitiesResponseDTO> GetspActivitiesByFiltersAsync(spGetActivitiesRequestDTO activities);

        List<spGetTimelineResponseDTO> GetspTimelineByFilterAsync(spGetTimelineRequestDTO timelines);
    }
}
