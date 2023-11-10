using LeadTracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface IAttendanceService
    {
        Task<LoginAttendanceDTO> LoginAttendance(LoginAttendanceDTO loginAttendance, int userId);
        Task LogoutAttendance(LogoutAttendanceDTO logoutAttendance, int userId);

        Task<List<AttendanceDTO>> GetspAttendanceAsync(spGetAllAttendanceDTO attendance);

        Task<List<AttendanceDTO>> UpdateAttendanceAsync(spUpdateAttendanceDTO attendance);
    }
}
