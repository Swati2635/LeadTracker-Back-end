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
    public class TrackerRepository : Repository<Tracker>, ITrackerRepository
    {
        private readonly LeadTrackerContext _context;
        public TrackerRepository(LeadTrackerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tracker>> GetTrackersByEnquiryIdAsync(int enquiryId)
        {
            return await _context.Trackers
                .Where(tracker => tracker.EnquiryId == enquiryId)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<string> GetCurrentStepByWorkFlowStepIdAsync(int workFlowStepId)
        {
            return await _context.WorkFlowSteps
                .Where(step => step.Id == workFlowStepId)
                .Select(step => step.StepName)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }


        public async Task CreateTrackerAsync(Tracker entity)
        {
            entity.IsActive = true;
            entity.CreatedDate = DateTime.UtcNow;
            entity.ModifiedDate = DateTime.UtcNow;
            entity.IsDeleted = false;


            var previousTrackers = _context.Set<Tracker>()
                .Where(t => t.EnquiryId == entity.EnquiryId)
                .ToList();

            foreach (var previousTracker in previousTrackers)
            {

                previousTracker.IsStepCompleted = true;
                _context.Entry(previousTracker).State = EntityState.Modified;
            }


            await _context.Set<Tracker>().AddAsync(entity).ConfigureAwait(false);


            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public List<spStepCountDTO> GetspCountsByUserIdandOrgIdAsync(int userId, int orgId)
        {
            var parameters = new List<SqlParameter>
            {
               new SqlParameter("@UserId", userId),
               new SqlParameter("@OrgId", orgId)
            };

            var result = _context.Set<spStepCountDTO>()
            .FromSqlRaw("GetTrackerStepCounts @UserId, @OrgId", parameters.ToArray()).ToList();
        
            return result;

        }

        public async Task<Tracker> CreateTrackerByLeadSourceAsync(Tracker tracker)
        {
            try
            {
                await _context.Trackers.AddAsync(tracker);
                await _context.SaveChangesAsync(); 

                return tracker; 
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating Tracker.", ex);
            }
        }

    }
}


