using LeadTracker.API;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.IRepository
{
    public interface IUserLocationRepository
    {
        UserLocation GetUserLocation(int userId, int orgId);

        void UpdateUserLocation(UserLocation location);

        void CreateUserLocation(UserLocation location);

        Task<List<UserLocation>> GetUserLocationsAsyncByOrgId(int orgId);

       
    }
}
