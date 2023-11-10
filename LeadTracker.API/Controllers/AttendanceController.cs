using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : BaseController
    {
        private readonly IAttendanceService _attendanceService;
        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpPost("PunchIn")]
        public async Task<IActionResult> LoginAttendance(LoginAttendanceDTO loginAttendance)
        {
            //var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);
            var _userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);
            var result = await _attendanceService.LoginAttendance(loginAttendance, _userId).ConfigureAwait(false);

            return Ok(result);
        }

       

        [HttpPut("PunchOut")]
        public async Task<IActionResult> LogoutAttendance(LogoutAttendanceDTO logoutAttendance)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);

            await _attendanceService.LogoutAttendance(logoutAttendance, userId).ConfigureAwait(false);

            return NoContent();
        }


        [HttpPost("Approved")]
        public async Task<ActionResult<List<AttendanceDTO>>> Approved([FromBody] spGetAllAttendanceDTO attendance)
        {
            var attendanceDTO = await _attendanceService.GetspAttendanceAsync(attendance).ConfigureAwait(false);
            
            return Ok(attendanceDTO);
        }


        [HttpPut("AttendanceApproval")]
        public async Task<ActionResult<List<AttendanceDTO>>> UpdateAttendance([FromBody] spUpdateAttendanceDTO attendance)
        {
            var attendances = await _attendanceService.UpdateAttendanceAsync(attendance).ConfigureAwait(false);

            return attendances;
        }
    }
}