using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLocationController : BaseController
    {
        private readonly IUserLocationService _userLocationService;

        public UserLocationController(IUserLocationService userLocationService)
        {
            _userLocationService = userLocationService;
        }

        [HttpPost("UpdateOrCreateUserLocation")]
        public async Task<IActionResult> UpdateOrCreateUserLocation(UserLocationDTO userLocation)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);
            var orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);

            var result = await _userLocationService.UpdateOrCreateUserLocation(userLocation, userId, orgId).ConfigureAwait(false);

            return Ok(result);
        }


        [HttpGet("GetAllUserLocationByOrg")]
        public async Task<ActionResult<UserLocationResponseDTO>> GetAllUserLocationByOrg()
        {
            
            var orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);

            var userLocations = await _userLocationService.GetAllUserLocationAsync(orgId);

            return Ok(userLocations);
        }



    }
}
