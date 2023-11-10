using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : BaseController
    {
        private readonly ILeadService _leadService;

        public LeadController(ILeadService leadService)
        {
            _leadService = leadService;
        }

        [HttpPost]
        public async Task<ActionResult> SaveLead(LeadDTO lead)
        {
            await _leadService.CreateLead(lead).ConfigureAwait(false);

            return Ok(lead);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeadDTO>> GetLead(int id)
        {
            var lead = await _leadService.GetLeadByIdAsync(id).ConfigureAwait(false);

            if (lead == null)
            {
                return NotFound();
            }

            return Ok(lead);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeadDTO>>> GetAllLead()
        {
            var lead = await _leadService.GetAllLeadAsync().ConfigureAwait(false);
            return Ok(lead);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLead(int id, LeadDTO lead)
        {
            if (id != lead.Id)
            {
                return BadRequest();
            }

            await _leadService.UpdateLeadAsync(id, lead).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLead(int id)
        {
            await _leadService.DeleteLeadAsync(id).ConfigureAwait(false);
            return NoContent();
        }


        //[HttpGet("GetEnquires/{currentStep}")]
        //public async Task<ActionResult<List<EnquiryDTO>>> GetEnquiriesByCurrentStep(string currentStep)
        //{

        //    var _userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);
        //    var _orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);
        //    //var _orgId = Convert.ToInt32(HttpContext.Items["OrgId"]);
        //    //var _userId = Convert.ToInt32(HttpContext.Items["UserId"])

        //    var enquiry = await _leadService.GetEnquiriesByCurrentStepAsync(_userId, _orgId, currentStep).ConfigureAwait(false);

        //    if (enquiry == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(enquiry);
        //}


        [HttpGet("GetEnquires/{currentStep}/{take}/{skip}")]
        public async Task<ActionResult<List<TrackerDTO>>> GetEnquiriesByCurrentStep(string currentStep, int take, int skip)
        {

            var _userId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("EmployeeId")).Value);
            var _orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);

            //var _orgId = Convert.ToInt32(HttpContext.Items["OrgId"]);
            //var _userId = Convert.ToInt32(HttpContext.Items["UserId"])

            var enquiry = await _leadService.GetEnquiriesByCurrentStepAsync(_userId, _orgId, currentStep, take, skip).ConfigureAwait(false);


            if (enquiry == null)
            {
                return NotFound();
            }

            return Ok(enquiry);
        }


    }
}


