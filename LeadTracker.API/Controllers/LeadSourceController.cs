using LeadTracker.BusinessLayer.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeadTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadSourceController : BaseController
    {
        private readonly ILeadSourceService _leadSourceService;

        public LeadSourceController(ILeadSourceService leadSourceService)
        {
            _leadSourceService = leadSourceService;
        }
    }
}
