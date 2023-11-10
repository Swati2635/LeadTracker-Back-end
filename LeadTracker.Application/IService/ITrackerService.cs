using LeadTracker.API;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface ITrackerService
    {
        Task CreateTracker(TrackerDTO tracker);

        Task<TrackerDTO> GetTrackerByIdAsync(int id);

        Task<IEnumerable<TrackerDTO>> GetAllTrackerAsync();

        Task UpdateTrackerAsync(int id, TrackerDTO tracker);

        Task DeleteTrackerAsync(int id);

        Task<EnquiryHistoryDTO> GetEnquiryHistoryByEnquiryIdAsync(int enquiryId);

        Task<List<spStepCountDTO>> GetspCountsByUserIdAsync(int userId, int orgId);

    }
}
