using LeadTracker.API;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure.Repository
{
    public class UserLocationRepository : IUserLocationRepository
    {
        public readonly LeadTrackerContext _context;

        public UserLocationRepository(LeadTrackerContext context)
        {
            this._context = context;
        }

        public UserLocation GetUserLocation(int userId, int orgId)
        {
            return _context.UserLocations
                .FirstOrDefault(ul => ul.UserId == userId && ul.OrgId == orgId);
        }

        public void UpdateUserLocation(UserLocation location)
        {
            _context.UserLocations.Update(location);
            _context.SaveChanges();
        }

        public void CreateUserLocation(UserLocation location)
        {
            _context.UserLocations.Add(location);
            _context.SaveChanges();
        }



        public async Task<List<UserLocation>> GetUserLocationsAsyncByOrgId(int orgId)
        {
            return await _context.UserLocations
                .Where(ul => ul.OrgId == orgId)
                .ToListAsync();
        }

    }
}
