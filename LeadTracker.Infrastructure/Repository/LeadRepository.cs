using LeadTracker.API;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.Repository
{
    public class LeadRepository : Repository<Lead>, ILeadRepository
    {
        private readonly LeadTrackerContext _context;
        public LeadRepository(LeadTrackerContext context) : base(context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<Tracker>> GetTrackersByCurrentStepAndAssignedToAsync(int userId, int orgId, List<int> workFlowStepIds, int currentStepId)
        //{
        //    return await _context.Trackers.Include(f => f.WorkFlow).Include(f => f.WorkFlowStep)
        //        .Where(f => f.WorkFlowStepId == currentStepId && workFlowStepIds.Contains(f.WorkFlowStepId.Value) && f.AssignedTo == userId)
        //        .ToListAsync()
        //        .ConfigureAwait(false);
        //}


        public async Task<IEnumerable<Tracker>> GetTrackersByCurrentStepAndAssignedToAsync(int userId, int orgId, List<int> workFlowStepIds)
        {
            var latestTrackers = _context.Trackers
                .Include(f => f.WorkFlow)
                .Include(f => f.WorkFlowStep)
                .Where(f => f.WorkFlowStepId.HasValue && workFlowStepIds.Contains(f.WorkFlowStepId.Value) && f.AssignedTo == userId)
                .GroupBy(t => t.EnquiryId)
                .Select(group => group.OrderByDescending(t => t.WorkFlowStepId).First())
                .ToListAsync();

            return await latestTrackers.ConfigureAwait(false);
        }



        public async Task<IEnumerable<Tracker>> GetLeadsByUserIdAndStepAsync(int userId, int orgId, int workFlowStepId, int take, int skip)
        {
            bool? isStepCompleted = false;

            var latestTrackers = _context.Trackers
                .Include(f => f.WorkFlow)
                .Include(f => f.WorkFlowStep)
                .Include(f => f.Enquiry)
                .Where(f => f.IsStepCompleted == isStepCompleted && (!f.IsDeleted) && f.IsActive &&
                f.WorkFlowStepId.HasValue && f.WorkFlowStepId.Value== workFlowStepId && f.AssignedTo == userId && f.OrgId == orgId)
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return await latestTrackers.ConfigureAwait(false);
        }




        //public async Task<IEnumerable<Tracker>> GetTrackersByCurrentStepAndAssignedToAsync(int userId, int orgId, List<int> workFlowStepIds)
        //{
        //    return await _context.Trackers.Include(f => f.WorkFlow).Include(f => f.WorkFlowStep)
        //        .Where(f => f.WorkFlowStepId.HasValue && workFlowStepIds.Contains(f.WorkFlowStepId.Value) && f.AssignedTo == userId)
        //        .ToListAsync()
        //        .ConfigureAwait(false);
        //}


        public async Task<IEnumerable<Lead>> GetLeadsByEnquiryIdsAsync(List<int> enquiryIds)
        {
            return await _context.Leads
                .Where(l => enquiryIds.Contains(l.Id))
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<Lead> CreateLeadAsync(Lead lead)
        {
            try
            {
                await _context.Leads.AddAsync(lead); // Add the new Lead to the context
                await _context.SaveChangesAsync(); // Save changes to the database asynchronously

                return lead; // Return the created Lead entity
            }
            catch (Exception ex)
            {
                // Handle any exceptions here, e.g., log the error or throw a custom exception
                throw new Exception("Error creating Lead.", ex);
            }
        }


    }
}
