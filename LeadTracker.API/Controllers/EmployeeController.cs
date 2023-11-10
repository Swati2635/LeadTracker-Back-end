using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LeadTracker.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;

        }

        [HttpPost]
        public async Task<ActionResult> SaveEmployee(EmployeeDTO employee)
        {
            await _employeeService.CreateEmployee(employee).ConfigureAwait(false);

            return Ok(employee);
        }


        [HttpPost("NewEmployee")]
        public async Task<ActionResult> NewEmployeeRegistration(NewEmployeeDTO employee)
        {
            var _userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);
            var _orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);


            await _employeeService.RegisterEmployee(employee, _orgId, _userId).ConfigureAwait(false);

            return Ok(employee);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id).ConfigureAwait(false);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployee()
        {
            var employee = await _employeeService.GetAllEmployeeAsync().ConfigureAwait(false);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeDTO employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            await _employeeService.UpdateEmployeeAsync(id, employee).ConfigureAwait(false);
            return NoContent();
        }


        [HttpPut("UpdateEmployee/{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, NewEmployeeDTO updatedEmployee)
        {
            try
            {
                if (id != updatedEmployee.Id)
                {
                    return BadRequest("Invalid employee ID.");
                }

                var updatedEmployeeResult = await _employeeService.EditEmployeeAsync(id, updatedEmployee).ConfigureAwait(false);

                if (updatedEmployeeResult != null)
                {
                    return Ok(updatedEmployeeResult);
                }
                else
                {
                    return NotFound("Employee not found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update employee: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id).ConfigureAwait(false);
            return NoContent();
        }


        [HttpGet("GetEmployeeAndChildren/{userId}")]
        public async Task<ActionResult<List<spParentAndChildrenDTO>>> GetEmployeesByUserId(int userId)
        {
           
            var _orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);

            var empls = await _employeeService.GetspEmployeesByUserIdAsync(userId, _orgId).ConfigureAwait(false);

            if (empls == null)
            {
                return NotFound();
            }

            return Ok(empls);
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO changePassword)
        {

            var success = await _employeeService.ChangePasswordAsync(changePassword);

            if (success)
            {
                return Ok(changePassword);
            }
            else
            {
                return BadRequest("Password change failed");
            }
        }


        [HttpGet("GetParentOfUsers")]
        public async Task<ActionResult<List<spParentDTO>>> GetParents()
        {
            //var _orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);

            var count = await _employeeService.GetspParentOfUsersAsync().ConfigureAwait(false);

            if (count == null)
            {
                return NotFound();
            }

            return Ok(count);
        }


        [HttpPost("GetActivitiesOfEmployees")]
        public async Task<ActionResult<List<spGetActivitiesResponseDTO>>> GetActivities([FromBody] spGetActivitiesRequestDTO activities)
        {
            var activitiesDto = await _employeeService.GetspActivitiesAsync(activities).ConfigureAwait(false);

            return Ok(activitiesDto);
        }


        [HttpPost("GetTimeLineOfActions")]
        public async Task<ActionResult<List<spGetTimelineResponseDTO>>> GetTimeline([FromBody] spGetTimelineRequestDTO timeline)
        {
            var timelineDto = await _employeeService.GetTimelineAsync(timeline).ConfigureAwait(false);


            return Ok(timelineDto);
        }


    }
}
