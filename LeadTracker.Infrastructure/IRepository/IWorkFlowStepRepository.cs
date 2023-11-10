using LeadTracker.API;
using LeadTracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.IRepository
{
    public interface IWorkFlowStepRepository : IRepository<WorkFlowStep>
    {
        Task<WorkFlow> GetWorkFlowByOrgIdAsync(int orgId);
        Task<WorkFlowStep> GetWorkFlowStepsByCurrentStepAsync(string currentStep, int orgId);
        Task<IEnumerable<WorkFlowStep>> GetWorkFlowStepByOrgIdByIdAsync(int orgId);
        Task<IEnumerable<NextStepDTO>> GetNextStepsByCurrentStepAsync(string currentStep, int currentStepWFId, int orgId);
    }
}
