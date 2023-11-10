using LeadTracker.API;
using LeadTracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.IRepository
{
    public interface ILeadSourceRepository : IRepository<LeadSource>
    {
        Task<IEnumerable<LeadSource>> GetLeadSourcesAsync(int take, int skip);

        Task UpdateLeadSourceAsync(LeadSource leadSource);

        Task<LeadSource> GetLeadSourceByIdAsync(int leadSourceId);

        //Task<bool> UploadManualLeadAsync(Lead lead);


    }
}
