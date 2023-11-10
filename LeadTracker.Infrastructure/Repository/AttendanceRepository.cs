using LeadTracker.API;
using LeadTracker.Core.DTO;
using LeadTracker.Infrastructure.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.Repository
{
    public class AttendanceRepository : Repository<Attendance>, IAttendanceRepository
    {
        private readonly LeadTrackerContext _context;
        public AttendanceRepository(LeadTrackerContext context) : base(context)
        {
            _context = context;
        }

        public Attendance GetLoginAttendance(int userId)
        {
            return _context.Attendances
                .FirstOrDefault(la => la.UserId == userId);
        }

        public void UpdateLoginAttendance(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
            _context.SaveChanges();
        }

        public void CreateLoginAttendance(Attendance attendance)
        {
            attendance.IsActive = true;
            attendance.CreatedDate = DateTime.Now;
            attendance.ModifiedDate = DateTime.Now;
            attendance.IsDeleted = false;

            _context.Attendances.Add(attendance);
            _context.SaveChanges();
        }

        public Attendance GetLogoutAttendance(int userId)
        {
            return _context.Attendances
                   .Where(la => la.UserId == userId)
                   .OrderByDescending(la => la.Id)
                   .FirstOrDefault();
        }

        public void UpdateLogoutAttendance(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
            _context.SaveChanges();
        }


        public List<AttendanceDTO> GetspAttendanceAsync(spGetAllAttendanceDTO attendance)
        {
            try
            {
                var defFromDt = DateTime.Now.Date;
                var defToDt = DateTime.Now.Date.AddHours(23).AddMinutes(59);
                attendance.StartDate = attendance.StartDate == DateTime.MinValue ? defFromDt : attendance.StartDate;
                attendance.EndDate = attendance.EndDate == DateTime.MinValue ? defToDt : attendance.EndDate;
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@UserId", attendance.UserId),
                    new SqlParameter("@StartDate", attendance.StartDate),
                    new SqlParameter("@EndDate", attendance.EndDate),
                    //new SqlParameter("@IsApproved", attendance.IsApproved),

                };
                var result = _context.Set<AttendanceDTO>()
                    .FromSqlRaw("spGetAllAttendance @UserId, @StartDate, @EndDate", parameters.ToArray())
                    .ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<AttendanceDTO> UpdateAttendanceAsync(spUpdateAttendanceDTO attendance)
        {
            try
            {
                var defFromDt = DateTime.Now.Date;
                var defToDt = DateTime.Now.Date.AddHours(23).AddMinutes(59);
                attendance.StartDate = attendance.StartDate == DateTime.MinValue ? defFromDt : attendance.StartDate;
                attendance.EndDate = attendance.EndDate == DateTime.MinValue ? defToDt : attendance.EndDate;

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@EmployeeId", attendance.EmployeeId),
                    new SqlParameter("@StartDate", attendance.StartDate),
                    new SqlParameter("@EndDate", attendance.EndDate),
                    new SqlParameter("@ApprovedBy", attendance.ApprovedBy)
                };

                var result = _context.Set<AttendanceDTO>()
                    .FromSqlRaw("spUpdateAttendance @EmployeeId, @StartDate, @EndDate, @ApprovedBy", parameters.ToArray())
                    .ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}