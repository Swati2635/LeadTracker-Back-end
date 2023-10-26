using LeadTracker.API;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LeadTracker.Infrastructure.Repository
{
    public class WorkFlowStepRepository : Repository<WorkFlowStep>, IWorkFlowStepRepository
    {
        private readonly LeadTrackerContext _context;
        public WorkFlowStepRepository(LeadTrackerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<WorkFlow> GetWorkFlowByOrgIdAsync(int orgId)
        {
            var workflow = _context.WorkFlows
                .Where(workflow => workflow.OrgId == orgId).ToList();

            return workflow.FirstOrDefault();
                
        }

        public async Task<IEnumerable<WorkFlowStep>> GetWorkFlowStepByOrgIdByIdAsync(int orgId)
        {
            return await _context.WorkFlowSteps
                .Where(workflowstep => workflowstep.OrgId == orgId)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<WorkFlowStep>> GetWorkFlowStepsByCurrentStepAsync(string currentStep, int orgId) 
        {

            return await _context.WorkFlowSteps
                .Where(workflowstep => workflowstep.OrgId == orgId && workflowstep.CurrentStep == currentStep)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<NextStepDTO>> GetNextStepsByCurrentStepAsync(string currentStep, int currentStepWFId, int orgId)
        {
            var nextSteps = await _context.WorkFlowSteps
                .Where(wfs => wfs.OrgId == orgId && wfs.PreviousStep == currentStep && wfs.WorkFlowId == currentStepWFId)
                .Select(wfs => new NextStepDTO { WorkFlowStepId = wfs.Id, WorkFlowId = wfs.WorkFlowId, NextStep = wfs.NextStep })
                .ToListAsync()
                .ConfigureAwait(false);

            return nextSteps;
        }





    }
}
