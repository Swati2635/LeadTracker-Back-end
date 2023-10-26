using LeadTracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface IDocumentService
    {
        Task CreateDocument(int userId, int orgId, DocumentDTO document);



        Task InsertStatus(StatusDTO status, int orgId, int userId);
    }
}
