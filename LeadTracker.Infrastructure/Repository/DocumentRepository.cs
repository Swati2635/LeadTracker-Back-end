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
using Document = LeadTracker.API.Document;

namespace LeadTracker.Infrastructure.Repository
{
    public class DocumentRepository : Repository<Document>, IDocumentRepository
    {

        private readonly LeadTrackerContext _context;
        public DocumentRepository(LeadTrackerContext context) : base(context)
        {
            _context = context;
        }


        public async Task CreateDocument(Document document)
        {
            document.IsActive = true;
            document.CreatedDate = DateTime.UtcNow;
            document.ModifiedDate = DateTime.UtcNow;
            document.IsDeleted = false;

            await (_context as LeadTrackerContext).Documents.AddAsync(document).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task CreateTracker(Tracker tracker)
        {
            tracker.IsActive = true;
            tracker.CreatedDate = DateTime.UtcNow;
            tracker.ModifiedDate = DateTime.UtcNow;
            tracker.IsDeleted = false;

            var previousTrackers = _context.Set<Tracker>()
               .Where(t => t.EnquiryId == tracker.EnquiryId)
               .ToList();

            foreach (var previousTracker in previousTrackers)
            {

                previousTracker.IsStepCompleted = true;
                _context.Entry(previousTracker).State = EntityState.Modified;
            }


            await (_context as LeadTrackerContext).Trackers.AddAsync(tracker).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task CreateAllAsync(List<Document> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsActive = true;
                entity.CreatedDate = DateTime.UtcNow;
                entity.ModifiedDate = DateTime.UtcNow;
                entity.IsDeleted = false;


                await (_context as LeadTrackerContext).Documents.AddAsync(entity).ConfigureAwait(false);
            }
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

       


    }
}
