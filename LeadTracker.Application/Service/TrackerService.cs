using AutoMapper;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure.IRepository;
using LeadTracker.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class TrackerService : ITrackerService
    {
        private readonly ITrackerRepository _trackerrepository;
        private readonly IMapper _mappingProfile;
        private readonly ILeadService _leadService;

        public TrackerService(ITrackerRepository trackerrepository, IMapper mappingProfile, ILeadService leadService)
        {
            _trackerrepository = trackerrepository;
            _mappingProfile = mappingProfile;
            _leadService = leadService;
        }

        public async Task CreateTracker(TrackerDTO tracker)
        {
            tracker.Enquiry = null;
            var track = _mappingProfile.Map<Tracker>(tracker);
            await _trackerrepository.CreateTrackerAsync(track).ConfigureAwait(false);
        }

        public async Task<TrackerDTO> GetTrackerByIdAsync(int id)
        {
            var tracker = await _trackerrepository.GetByIdAsync(id);

            var trackerDTO = _mappingProfile.Map<TrackerDTO>(tracker);
            return trackerDTO;
        }

        public async Task<IEnumerable<TrackerDTO>> GetAllTrackerAsync()
        {
            var trackers = await _trackerrepository.GetAllAsync();
            var trackersDTO = _mappingProfile.Map<List<TrackerDTO>>(trackers);
            return trackersDTO.ToList();
        }

        public async Task UpdateTrackerAsync(int id, TrackerDTO tracker)
        {
            var existingTracker = await _trackerrepository.GetByIdAsync(id);
            _mappingProfile.Map(tracker, existingTracker);
            await _trackerrepository.UpdateAsync(existingTracker);

            
        }

        public async Task DeleteTrackerAsync(int id)
        {
            var tracker = await _trackerrepository.GetByIdAsync(id);
            if (tracker != null)
            {
                await _trackerrepository.DeleteAsync(id);
            }
        }

        public async Task<EnquiryHistoryDTO> GetEnquiryHistoryByEnquiryIdAsync(int enquiryId)
        {
            var lead = await _leadService.GetLeadByIdAsync(enquiryId).ConfigureAwait(false);
            var trackers = await _trackerrepository.GetTrackersByEnquiryIdAsync(enquiryId).ConfigureAwait(false);

            if (lead == null || !trackers.Any())
            {
                return null;
            }

            var enquiryHistory = new EnquiryHistoryDTO
            {
                Lead = _mappingProfile.Map<LeadDTO>(lead),
                Trackers = _mappingProfile.Map<List<TrackerDTO>>(trackers).ToList()
            };


            foreach (var tracker in enquiryHistory.Trackers)
            {
                string currentStep = await _trackerrepository.GetCurrentStepByWorkFlowStepIdAsync(tracker.WorkFlowStepId ?? 0).ConfigureAwait(false);
                tracker.CurrentStep = currentStep;
            }

            return enquiryHistory;
        }



        public async Task<List<spStepCountDTO>> GetspCountsByUserIdAsync(int userId, int orgId)
        {
            var stepCount = _trackerrepository.GetspCountsByUserIdandOrgIdAsync(userId, orgId);

            if (stepCount == null)
            {
                return null;
            }

            var StepCount = _mappingProfile.Map<List<spStepCountDTO>>(stepCount).ToList();
            
            return StepCount;
        }


        //public async Task<EnquiryHistoryDTO> GetEnquiryHistoryByEnquiryIdAsync(int enquiryId)
        //{
        //    var lead = await _leadService.GetLeadByIdAsync(enquiryId).ConfigureAwait(false);
        //    var trackers = await _trackerrepository.GetTrackersByEnquiryIdAsync(enquiryId).ConfigureAwait(false);

        //    if (lead == null || !trackers.Any())
        //    {
        //        return null;
        //    }

        //    var enquiryHistory = new EnquiryHistoryDTO
        //    {
        //        Lead = _mappingProfile.Map<LeadDTO>(lead),
        //        Trackers = _mappingProfile.Map<List<TrackerDTO>>(trackers).ToList()
        //    };

        //    var secondTracker = trackers.Skip(1).FirstOrDefault();
        //    if (secondTracker != null)
        //    {
        //        string currentStep = await _trackerrepository.GetCurrentStepByWorkFlowStepIdAsync(secondTracker.WorkFlowStepId ?? 0).ConfigureAwait(false);
        //        enquiryHistory.CurrentStep = currentStep;
        //    }

        //    return enquiryHistory;
        //}



    }
}
