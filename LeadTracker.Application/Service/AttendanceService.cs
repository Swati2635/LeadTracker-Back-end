using AutoMapper;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using LeadTracker.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendancerepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mappingProfile;
        //public string Date = "DD/MM/YYYY";

        public AttendanceService(IMapper mappingProfile, IAttendanceRepository attendanceService, IEmployeeRepository employeeRepository)
        {
            _mappingProfile = mappingProfile;
            _attendancerepository = attendanceService;
            _employeeRepository = employeeRepository;
        }

        public async Task<LoginAttendanceDTO> LoginAttendance(LoginAttendanceDTO loginAttendance, int userId)
        {
            var existingLoginAttendance = _attendancerepository.GetLoginAttendance(userId);

            if (existingLoginAttendance != null && existingLoginAttendance.LoginDate.Value.Date == DateTime.Now.Date)
            {
                existingLoginAttendance.LoginLatitude = loginAttendance.LoginLatitude;
                existingLoginAttendance.LoginLongitude = loginAttendance.LoginLongitude;
                existingLoginAttendance.LoginDate = DateTime.Now;
                _attendancerepository.UpdateLoginAttendance(existingLoginAttendance);
            }
            else
            {
                Attendance attendances = new Attendance
                {
                    UserId = userId,
                    LoginLatitude = loginAttendance.LoginLatitude,
                    LoginLongitude = loginAttendance.LoginLongitude,
                    LoginDate = DateTime.Now
                };
                _attendancerepository.CreateLoginAttendance(attendances);
            }
            return loginAttendance;
        }

        public async Task LogoutAttendance(LogoutAttendanceDTO logoutAttendance, int userId)
        {
            var existingLogoutAttendance = _attendancerepository.GetLogoutAttendance(userId);

            if (existingLogoutAttendance != null || existingLogoutAttendance.LoginDate.Value.Date == DateTime.MinValue.Date)
            {
                existingLogoutAttendance.LogoutLatitude = logoutAttendance.LogoutLatitude;
                existingLogoutAttendance.LogoutLongitude = logoutAttendance.LogoutLongitude;
                existingLogoutAttendance.LogoutDate = DateTime.Now;

                _attendancerepository.UpdateLogoutAttendance(existingLogoutAttendance);
            }
        }

        public async Task<List<AttendanceDTO>> GetspAttendanceAsync(spGetAllAttendanceDTO attendance)
        {
            try
            {
                var spAttendance = _attendancerepository.GetspAttendanceAsync(attendance);

                if (spAttendance == null)
                {
                    return null;
                }

                var spAttendanceDTO = _mappingProfile.Map<List<AttendanceDTO>>(spAttendance).ToList();

                return spAttendanceDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<AttendanceDTO>> UpdateAttendanceAsync(spUpdateAttendanceDTO attendance)
        {
            try
            {
                var attendances = _attendancerepository.UpdateAttendanceAsync(attendance);

                if (attendances == null)
                {
                    return null;
                }
                var attendanceDTO = _mappingProfile.Map<List<AttendanceDTO>>(attendances).ToList();

                return attendanceDTO;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}