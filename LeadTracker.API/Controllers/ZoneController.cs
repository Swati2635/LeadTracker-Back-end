using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneController : BaseController
    {
        private readonly IZoneService _zoneService;

        public ZoneController(IZoneService zoneService)
        {
            _zoneService = zoneService;
        }

        [HttpPost]
        public async Task<ActionResult> SaveZone(ZoneDTO zone)
        {
            await _zoneService.CreateZone(zone).ConfigureAwait(false);
             
            return Ok(zone);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ZoneDTO>> GetZone(int id)
        {
            var zone = await _zoneService.GetZoneByIdAsync(id).ConfigureAwait(false);

            if (zone == null)
            {
                return NotFound();
            }

            return Ok(zone);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZoneDTO>>> GetAllZone()
        {
            var zone = await _zoneService.GetAllZoneAsync().ConfigureAwait(false);
            return Ok(zone);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateZone(int id, ZoneDTO zone)
        {
            if (id != zone.ZoneId)
            {
                return BadRequest();
            }

            await _zoneService.UpdateZoneAsync(id, zone).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZone(int id)
        {
            await _zoneService.DeleteZoneAsync(id).ConfigureAwait(false);
            return NoContent();
        }
    }
}
