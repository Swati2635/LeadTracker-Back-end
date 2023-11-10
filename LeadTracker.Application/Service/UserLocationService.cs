using AutoMapper;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Core.Extension;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class UserLocationService : IUserLocationService
    {
        private readonly IUserLocationRepository _userLocationRepository;
        private readonly IMapper _mappingProfile;
        private readonly IEmployeeRepository _employeeRepository;

        public UserLocationService(IUserLocationRepository userLocationRepository, IMapper mappingProfile, IEmployeeRepository employeeRepository)
        {
            _userLocationRepository = userLocationRepository;
            _mappingProfile = mappingProfile;
            _employeeRepository = employeeRepository;
        }




        public async Task<UserLocationDTO> UpdateOrCreateUserLocation(UserLocationDTO userLocation, int userId, int orgId)
        {
            var existingUserLocation = _userLocationRepository.GetUserLocation(userId, orgId);

            if (existingUserLocation != null && existingUserLocation.Date.Value.Date == DateTime.Now.Date)
            {

                existingUserLocation.CurrentLatitude = userLocation.CurrentLatitude;
                existingUserLocation.CurrentLongitude = userLocation.CurrentLongitude;
                existingUserLocation.Date = DateTime.Now;
                _userLocationRepository.UpdateUserLocation(existingUserLocation);
            }
            else
            {

                UserLocation newLocation = new UserLocation
                {
                    UserId = userId,
                    CurrentLatitude = userLocation.CurrentLatitude,
                    CurrentLongitude = userLocation.CurrentLongitude,
                    OrgId = orgId,
                    Date = DateTime.Now,
                    StartLatitude = userLocation.CurrentLatitude,
                    StartLongitude = userLocation.CurrentLongitude,
                };

                _userLocationRepository.CreateUserLocation(newLocation);
            }

            return userLocation;
        }

        public async Task<IEnumerable<UserLocationResponseDTO>> GetAllUserLocationAsync(int orgId)
        {
            var userLocations = await _userLocationRepository.GetUserLocationsAsyncByOrgId(orgId);

            var userLocationResponseDTOs = new List<UserLocationResponseDTO>();

            foreach (var userLocation in userLocations)
            {
                var userLocationResponseDTO = _mappingProfile.Map<UserLocationResponseDTO>(userLocation);
                userLocationResponseDTO.Employee = _mappingProfile.Map<EmployeeDTO>(
                    await _employeeRepository.GetByIdAsync(userLocation.UserId ?? 0)
                );
                userLocationResponseDTOs.Add(userLocationResponseDTO);
            }

            return userLocationResponseDTOs;
        }

    }
}
