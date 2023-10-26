using LeadTracker.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.IRepository
{
    public interface IDocumentRepository : IRepository<Document>
    {
        Task CreateDocument(Document document);
        Task CreateTracker(Tracker tracker);
        Task CreateAllAsync(List<Document> entities);

    }
}
