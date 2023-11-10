using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackerController : BaseController
    {
        private readonly ITrackerService _trackerService;

        public TrackerController(ITrackerService trackerService)
        {
            _trackerService = trackerService;

        }


        [HttpPost]
        public async Task<ActionResult> SaveTracker(TrackerDTO tracker)
        {
            await _trackerService.CreateTracker(tracker).ConfigureAwait(false);

            return Ok(tracker);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrackerDTO>> GetTracker(int id)
        {
            var tracker = await _trackerService.GetTrackerByIdAsync(id).ConfigureAwait(false);

            if (tracker == null)
            {
                return NotFound();
            }

            return Ok(tracker);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrackerDTO>>> GetAllTracker()
        {
            var tracker = await _trackerService.GetAllTrackerAsync().ConfigureAwait(false);
            return Ok(tracker);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTracker(int id, TrackerDTO tracker)
        {
            if (id != tracker.EnquiryId)
            {
                return BadRequest();
            }

            await _trackerService.UpdateTrackerAsync(id, tracker).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTracker(int id)
        {
            await _trackerService.DeleteTrackerAsync(id).ConfigureAwait(false);
            return NoContent();
        }

        [HttpGet("GetEnquiryHistoryByEnquiryId/{enquiryId}")]
        public async Task<ActionResult<EnquiryHistoryDTO>> GetEnquiryHistoryByEnquiryId(int enquiryId)
        {
            var enquiryHistory = await _trackerService.GetEnquiryHistoryByEnquiryIdAsync(enquiryId).ConfigureAwait(false);

            if (enquiryHistory == null)
            {
                return NotFound();
            }

            return Ok(enquiryHistory);
        }


        [HttpGet("GetCountOfWorkFlowStep/{userId}")]
        public async Task<ActionResult<List<spStepCountDTO>>> GetCountOfStepByUserId(int userId)
        {
            var _orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);

            var count = await _trackerService.GetspCountsByUserIdAsync(userId, _orgId).ConfigureAwait(false);

            if (count == null)
            {
                return NotFound();
            }

            return Ok(count);
        }

    }
}
