using AutoMapper;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using LeadTracker.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class LoginService : ILoginService
    {
        private readonly IEmployeeRepository _employeerepository;
        private readonly IMapper _mappingProfile;


        public LoginService(IMapper mappingProfile, IEmployeeRepository employeeService)
        {
            _mappingProfile = mappingProfile;
            _employeerepository = employeeService;

        }
       
        public async Task<EmployeeDTO> GetUser(string mobile, string password)
        {
            var user = await _employeerepository.GetUserLoginAsync(mobile, password);

            if (user == null) 
            {
                throw new KeyNotFoundException("Invalid User Details.");
            }
            var emp = _mappingProfile.Map<EmployeeDTO>(user);
            emp.Id = user.Id;

            return emp;
        }

    }
}
