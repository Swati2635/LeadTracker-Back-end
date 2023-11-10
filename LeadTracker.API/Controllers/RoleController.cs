using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LeadTracker.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService= roleService;
        }

        [HttpPost]
        public async Task<ActionResult> SaveRole(RoleDTO role)
        {
            await _roleService.CreateRole(role).ConfigureAwait(false);

            return Ok(role);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDTO>> GetRole(int id)
        {
            var role = await _roleService.GetRoleByIdAsync(id).ConfigureAwait(false);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> GetAllRole()
        {
            var role = await _roleService.GetAllRoleAsync().ConfigureAwait(false);
            return Ok(role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, RoleDTO role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }

            await _roleService.UpdateRoleAsync(id, role).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await _roleService.DeleteRoleAsync(id).ConfigureAwait(false);
            return NoContent();
        }

    }
}
