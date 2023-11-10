using LeadTracker.API;
using LeadTracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.IRepository
{
    public interface IAttendanceRepository : IRepository<Attendance>
    {
        Attendance GetLoginAttendance(int userId);
        void UpdateLoginAttendance(Attendance attendance);
        void CreateLoginAttendance(Attendance attendance);
        Attendance GetLogoutAttendance(int userId);
        void UpdateLogoutAttendance(Attendance attendance);

        List<AttendanceDTO> GetspAttendanceAsync(spGetAllAttendanceDTO attendance);

        List<AttendanceDTO> UpdateAttendanceAsync(spUpdateAttendanceDTO attendance);
    }
}
