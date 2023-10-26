using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.IService
{
    public interface IUserLocationService
    {
        Task<UserLocationDTO> UpdateOrCreateUserLocation(UserLocationDTO userLocation, int userId, int orgId);

        Task<IEnumerable<UserLocationResponseDTO>> GetAllUserLocationAsync(int orgId);

        
    }
}
