using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Core.DTO;
using LeadTracker.Infrastructure.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadSourceController : ControllerBase
    {
        private readonly ILeadSourceService _leadSourceService;
        private readonly ILeadRepository _leadRepository;

        public LeadSourceController(ILeadSourceService leadSourceService, ILeadRepository leadRepository)
        {
            _leadSourceService = leadSourceService;
            _leadRepository = leadRepository;

        }

        [HttpPost]
        [Route("UploadExcelFile")]
        public async Task<IActionResult> UploadExcelFile([FromForm] LeadSourceDTO leadSource)
        {
            UploadXMLFileResponse response = new UploadXMLFileResponse();
            string path = "Upload\\Files\\" + leadSource.Files.FileName;
            try
            {
                using (FileStream stream = new FileStream(path, FileMode.CreateNew))
                {
                    await leadSource.Files.CopyToAsync(stream);
                }

                response = await _leadSourceService.UploadXMLFile(leadSource, path);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;

            }

            return Ok(response);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<LeadSourceGetDTO>> GetLeadSource(int id)
        {
            var leadSource = await _leadSourceService.GetLeadSourceByIdAsync(id).ConfigureAwait(false);

            if (leadSource == null)
            {
                return NotFound();
            }

            return Ok(leadSource);
        }



        [HttpGet("GetLeads/{take}/{skip}")]
        public async Task<ActionResult<List<LeadSourceGetDTO>>> GetLeadSourceByStep(int take, int skip)
        {

            var leadSource = await _leadSourceService.GetLeadSourceByStepAsync(take, skip).ConfigureAwait(false);


            if (leadSource == null)
            {
                return NotFound();
            }

            return Ok(leadSource);
        }

        [HttpPost("TransferData")]
        public async Task<IActionResult> TransferLeadData([FromBody] LeadAssignDTO leadAssign)
        {
            try
            {
                if (leadAssign.AssignedTo == 0 || leadAssign.LeadSourceId == null || !leadAssign.LeadSourceId.Any())
                {
                    return BadRequest("Invalid parameters.");
                }
                var orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);

                var (createdLeads, createdTrackers) = await _leadSourceService.TransferDataAsync(leadAssign.AssignedTo, leadAssign.LeadSourceId, orgId);

                if (createdLeads.Count > 0 || createdTrackers.Count > 0)
                {
                    
                    return Ok(new
                    {
                        Leads = createdLeads,
                        Trackers = createdTrackers,
                        Message = "Data transfer completed."
                    });
                }
                else
                {
                    return BadRequest("No data transferred.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Data transfer failed: {ex.Message}");
            }
        }



        //[HttpPost("TransferData")]
        //public async Task<IActionResult> TransferLeadData([FromBody] LeadAssignDTO leadAssign)
        //{
        //    try
        //    {
        //        if (leadAssign.AssignedTo == 0 || leadAssign.LeadSourceId == null || !leadAssign.LeadSourceId.Any())
        //        {
        //            return BadRequest("Invalid parameters.");
        //        }
        //        var orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);

        //        await _leadSourceService.TransferDataAsync(leadAssign.AssignedTo, leadAssign.LeadSourceId, orgId);

        //        return Ok("Data transfer completed.");

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Data transfer failed: {ex.Message}");
        //    }
        //}

        [HttpPost("UploadManualLead")]
        public async Task<IActionResult> UploadManualLead(LeadManualDTO manualLead)
        {

             var leadSourceID = await _leadSourceService.CreateLeadAsync(manualLead);

            
            var _orgId = Convert.ToInt32(HttpContext.User.FindFirst(a => a.Type.Equals("OrgId")).Value);

            var (createdLeads, createdTrackers) = await _leadSourceService.TransferDataAsync(manualLead.AssignedTo, new List<int>() { leadSourceID }, _orgId);

            return Ok(new { createdLeads, createdTrackers });
        }



    }
}
