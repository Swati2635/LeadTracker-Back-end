using LeadTracker.API;
using LeadTracker.Core.DTO;
using LeadTracker.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.Repository
{
    public class LeadSourceRepository : Repository<LeadSource>, ILeadSourceRepository
    {
        private readonly LeadTrackerContext _context;

        public LeadSourceRepository(LeadTrackerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LeadSource>> GetLeadSourcesAsync(int take, int skip)
        {
            var leadSources = await _context.LeadSources
                .Where(ls => ls.IsActive == true && ls.IsDeleted == false && ls.IsProcessed == false)
                .OrderBy(ls => ls.CreatedDate)
                .Skip(skip)
                .Take(take)
                .ToListAsync()
                .ConfigureAwait(false);

            return leadSources;
        }
        public async Task UpdateLeadSourceAsync(LeadSource leadSource)
        {
            _context.Entry(leadSource).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<LeadSource> GetLeadSourceByIdAsync(int leadSourceId)
        {
            return await _context.LeadSources.FirstOrDefaultAsync(ls => ls.Id == leadSourceId);
        }


    }
}
