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
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IWorkFlowStepRepository _workFlowStepRepository;
        private readonly IMapper _mappingProfile;

        public LeadService(IMapper mappingProfile, ILeadRepository leadRepository, IWorkFlowStepRepository workFlowStepRepository)
        {
            _mappingProfile = mappingProfile;
            _leadRepository = leadRepository;
            _workFlowStepRepository = workFlowStepRepository;

        }
        public async Task CreateLead(LeadDTO lead)
        {
            var led = _mappingProfile.Map<Lead>(lead);
            await _leadRepository.CreateAsync(led).ConfigureAwait(false);
        }
        public async Task<LeadDTO> GetLeadByIdAsync(int id)
        {
            var lead = await _leadRepository.GetByIdAsync(id);

            var leadDTO = _mappingProfile.Map<LeadDTO>(lead);
            return leadDTO;
        }
        public async Task<IEnumerable<LeadDTO>> GetAllLeadAsync()
        {
            var leads = await _leadRepository.GetAllAsync();

            var leadsDTO = _mappingProfile.Map<List<LeadDTO>>(leads);
            return leadsDTO.ToList();
        }

        public async Task UpdateLeadAsync(int id, LeadDTO lead)
        {
            var existingLead = await _leadRepository.GetByIdAsync(id);
            _mappingProfile.Map(lead, existingLead);
            await _leadRepository.UpdateAsync(existingLead);

        }

        public async Task DeleteLeadAsync(int id)
        {
            var lead = await _leadRepository.GetByIdAsync(id);
            if (lead != null)
            {
                await _leadRepository.DeleteAsync(id);
            }

        }

        //public async Task<IEnumerable<EnquiryDTO>> GetEnquiriesByCurrentStepAsync(int userId, int orgId, string currentStep)
        //{
        //    var workflowSteps = await _workFlowStepRepository.GetWorkFlowStepsByCurrentStepAsync(currentStep, orgId);
        //    var trackers = await _leadRepository.GetTrackersByCurrentStepAndAssignedToAsync(userId, orgId, workflowSteps.Select(f => f.Id).ToList()).ConfigureAwait(false);

        //    var trackerGroups = trackers.Where(t => t.EnquiryId.HasValue).GroupBy(t => t.EnquiryId.Value).ToList();

        //    var enquiryIds = trackerGroups.Select(group => group.Key).ToList();
        //    var leads = await _leadRepository.GetLeadsByEnquiryIdsAsync(enquiryIds).ConfigureAwait(false);

        //    var result = new List<EnquiryDTO>();

        //    foreach (var lead in leads)
        //    {
        //        var enquiryId = lead.Id;
        //        var trackerGroup = trackerGroups.FirstOrDefault(group => group.Key == enquiryId);

        //        if (trackerGroup != null)
        //        {

        //            if (trackerGroup.All(t => t.IsDeleted != true && t.IsDeleted != true))
        //            {
        //                var leadDTO = _mappingProfile.Map<LeadDTO>(lead);

        //                var trackerDTOs = _mappingProfile.Map<List<TrackerDTO>>(
        //                    trackerGroup.Where(t => t.IsDeleted != true && t.IsDeleted != true).ToList()
        //                );

        //                var enquiryLeadWithTrackersDTO = new EnquiryDTO
        //                {
        //                    Lead = leadDTO,
        //                    Trackers = trackerDTOs
        //                };

        //                result.Add(enquiryLeadWithTrackersDTO);
        //            }
        //        }
        //    }

        //    return result;
        //}

        public async Task<IEnumerable<TrackerDTO>> GetEnquiriesByCurrentStepAsync(int userId, int orgId, string currentStep, int take, int skip)
        {
            
            var workflowStep = await _workFlowStepRepository.GetWorkFlowStepsByCurrentStepAsync(currentStep, orgId);
            var trackers = await _leadRepository.GetLeadsByUserIdAndStepAsync(userId, orgId,workflowStep.Id, take, skip).ConfigureAwait(false);

            var trackerDTOs = _mappingProfile.Map<List<TrackerDTO>>(trackers);

            
            foreach (var trackerDTO in trackerDTOs)
            {
                trackerDTO.CurrentStep = currentStep;
            }

            return trackerDTOs;


            /* var trackerGroups = trackers.Where(t => t.EnquiryId.HasValue).GroupBy(t => t.EnquiryId.Value).ToList();

             var enquiryIds = trackerGroups.Select(group => group.Key).ToList();
             var leads = await _leadRepository.GetLeadsByEnquiryIdsAsync(enquiryIds).ConfigureAwait(false);

             var result = new List<EnquiryDTO>();

             foreach (var lead in leads)
             {
                 var enquiryId = lead.Id;
                 var trackerGroup = trackerGroups.FirstOrDefault(group => group.Key == enquiryId);

                 if (trackerGroup != null)
                 {

                     if (trackerGroup.All(t => t.IsDeleted != true && t.IsDeleted != true))
                     {
                         var leadDTO = _mappingProfile.Map<LeadDTO>(lead);

                         var trackerDTOs = _mappingProfile.Map<List<TrackerDTO>>(
                             trackerGroup.Where(t => t.IsDeleted != true && t.IsDeleted != true).ToList()
                         );

                         var enquiryLeadWithTrackersDTO = new EnquiryDTO
                         {
                             Lead = leadDTO,
                             Trackers = trackerDTOs
                         };

                         result.Add(enquiryLeadWithTrackersDTO);
                     }
                 }
             }

             return result;
            */
        }

        //public async Task<IEnumerable<EnquiryDTO>> GetEnquiriesByCurrentStepAsync(int userId, int orgId, string currentStep)
        //{
        //    var workflowSteps = await _workFlowStepRepository.GetWorkFlowStepsByCurrentStepAsync(currentStep, orgId);
        //    var trackers = await _leadRepository.GetTrackersByCurrentStepAndAssignedToAsync(userId, orgId, workflowSteps.Select(f => f.Id).ToList()).ConfigureAwait(false);


        //    var trackerGroups = trackers.Where(t => t.EnquiryId.HasValue).GroupBy(t => t.EnquiryId.Value).ToList();


        //    var enquiryIds = trackerGroups.Select(group => group.Key).ToList();
        //    var leads = await _leadRepository.GetLeadsByEnquiryIdsAsync(enquiryIds).ConfigureAwait(false);

        //    var result = new List<EnquiryDTO>();

        //    foreach (var lead in leads)
        //    {
        //        var enquiryId = lead.Id;
        //        var trackerGroup = trackerGroups.FirstOrDefault(group => group.Key == enquiryId);

        //        if (trackerGroup != null)
        //        {
        //            var leadDTO = _mappingProfile.Map<LeadDTO>(lead);
        //            var trackerDTOs = _mappingProfile.Map<List<TrackerDTO>>(trackerGroup.ToList());

        //            var enquiryLeadWithTrackersDTO = new EnquiryDTO
        //            {
        //                Lead = leadDTO,
        //                Trackers = trackerDTOs
        //            };

        //            result.Add(enquiryLeadWithTrackersDTO);
        //        }
        //    }

        //    return result;
        //}





        //public async Task<IEnumerable<EnquiryDTO>> GetEnquiriesByCurrentStepAsync(int userId, int orgId, string currentStep)
        //{
        //    // Get the current step id
        //    var currentStepId = await _workFlowStepRepository.GetWorkFlowStepIdByStepNameAsync(currentStep, orgId).ConfigureAwait(false);

        //    // Get all the steps that are more recent than the current step
        //    var recentSteps = await _workFlowStepRepository.GetRecentStepsAsync(currentStepId ?? 0, orgId).ConfigureAwait(false);

        //    // Get the EnquiryIds associated with these recent steps
        //    var recentStepIds = recentSteps.Select(step => step.Id).ToList();
        //    var trackers = await _leadRepository.GetTrackersByCurrentStepAndAssignedToAsync(userId, orgId, recentStepIds).ConfigureAwait(false);

        //    var trackerGroups = trackers.Where(t => t.EnquiryId.HasValue).GroupBy(t => t.EnquiryId.Value).ToList();

        //    var enquiryIds = trackerGroups.Select(group => group.Key).ToList();
        //    var leads = await _leadRepository.GetLeadsByEnquiryIdsAsync(enquiryIds).ConfigureAwait(false);

        //    var result = new List<EnquiryDTO>();

        //    foreach (var lead in leads)
        //    {
        //        var enquiryId = lead.Id;
        //        var trackerGroup = trackerGroups.FirstOrDefault(group => group.Key == enquiryId);

        //        if (trackerGroup != null)
        //        {
        //            var leadDTO = _mappingProfile.Map<LeadDTO>(lead);
        //            var trackerDTOs = _mappingProfile.Map<List<TrackerDTO>>(trackerGroup.ToList());

        //            var enquiryLeadWithTrackersDTO = new EnquiryDTO
        //            {
        //                Lead = leadDTO,
        //                Trackers = trackerDTOs
        //            };

        //            result.Add(enquiryLeadWithTrackersDTO);
        //        }
        //    }

        //    return result;
        //}


    }
}
