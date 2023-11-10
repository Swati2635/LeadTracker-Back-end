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
    public interface ILeadRepository : IRepository<Lead>
    {


        Task<IEnumerable<Tracker>> GetTrackersByCurrentStepAndAssignedToAsync(int userId, int orgId, List<int> workFlowStepIds);

        Task<IEnumerable<Lead>> GetLeadsByEnquiryIdsAsync(List<int> enquiryIds);

        Task<IEnumerable<Tracker>> GetLeadsByUserIdAndStepAsync(int userId, int orgId, int workFlowStepId, int take, int skip);

        // Task<string> GetCurrentStepByWorkFlowStepIdAsync(int workFlowStepId);

        Task<Lead> CreateLeadAsync(Lead lead);

    }
}
