using LeadTracker.API;
using LeadTracker.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface ILeadSourceService
    {
        Task<UploadXMLFileResponse> UploadXMLFile(LeadSourceDTO leadSource, string path);
        Task<LeadSourceGetDTO> GetLeadSourceByIdAsync(int id);
        Task<IEnumerable<LeadSourceGetDTO>> GetLeadSourceByStepAsync(int take, int skip);
        Task<(List<Lead>, List<Tracker>)> TransferDataAsync(int assignedTo, List<int> leadSourceIds, int orgId);
        //Task<bool> UploadManualLeadAsync(LeadManualDTO manualLead);

        Task<int> CreateLeadAsync(LeadManualDTO manualLead);
    }
}
