using LeadTracker.API;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.IRepository
{
    public interface ITrackerRepository : IRepository<Tracker>
    {
        Task<IEnumerable<Tracker>> GetTrackersByEnquiryIdAsync(int enquiryId);
        Task<string> GetCurrentStepByWorkFlowStepIdAsync(int workFlowStepId);
        Task CreateTrackerAsync(Tracker entity);
        List<spStepCountDTO> GetspCountsByUserIdandOrgIdAsync(int userId, int orgId);
        Task<Tracker> CreateTrackerByLeadSourceAsync(Tracker tracker);

    }
}
