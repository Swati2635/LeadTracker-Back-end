using AutoMapper;
using LeadTracker.API;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using LeadTracker.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.BusinessLayer.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeerepository;
        private readonly IMapper _mappingProfile;


        public EmployeeService(IMapper mappingProfile, IEmployeeRepository employeeService)
        {
            _mappingProfile = mappingProfile;
            _employeerepository = employeeService;

        }

        public async Task CreateEmployee(EmployeeDTO employee)
        {
            var empl = _mappingProfile.Map<Employee>(employee);
            await _employeerepository.CreateAsync(empl).ConfigureAwait(false);
        }


        public async Task RegisterEmployee(NewEmployeeDTO employee, int orgId, int userId)
        {
            Employee newEmployee = new Employee
            {
                Name = employee.Name,
                EmailId = employee.EmailId,
                UserName = employee.UserName,
                Password = "1234",
                Mpin = "1234",
                Mobile = employee.Mobile,
                ParentUserId = employee.ParentUserId,
                OrgId = orgId,
                CreatedBy = userId, 
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                ModifiedBy= userId,
                Gender = employee.Gender,
                RoleId = employee.RoleId,
                Photo = null
            };

            await _employeerepository.CreateAsync(newEmployee).ConfigureAwait(false);
        }




        public async Task<Employee> EditEmployeeAsync(int id, NewEmployeeDTO updatedEmployee)
        {
            var existingEmployee = await _employeerepository.GetByIdAsync(id);

            if (existingEmployee != null)
            {
                existingEmployee.Name = updatedEmployee.Name;
                existingEmployee.EmailId = updatedEmployee.EmailId;
                existingEmployee.UserName = updatedEmployee.UserName;
                existingEmployee.Mobile = updatedEmployee.Mobile;
                existingEmployee.ParentUserId = updatedEmployee.ParentUserId;
                existingEmployee.ModifiedDate = DateTime.Now;
                existingEmployee.Gender = updatedEmployee.Gender;
                existingEmployee.RoleId = updatedEmployee.RoleId;

                
                await _employeerepository.UpdateAsync(existingEmployee);

                return existingEmployee;
            }

            return null;
        }





        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeerepository.GetByIdAsync(id);

            var employeeDTO = _mappingProfile.Map<EmployeeDTO>(employee);
            return employeeDTO;
        }


        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeeAsync()
        {
            var employees = await _employeerepository.GetAllAsync();

            var filteredEmployees = employees.Where(e => e.IsActive == true && e.IsDeleted == false).ToList();

            var employeesDTO = _mappingProfile.Map<List<EmployeeDTO>>(filteredEmployees);

            return employeesDTO.ToList();
        }


        public async Task UpdateEmployeeAsync(int id, EmployeeDTO employee)
        {
            var existingEmployee = await _employeerepository.GetByIdAsync(id);


            _mappingProfile.Map(employee, existingEmployee);


            await _employeerepository.UpdateAsync(existingEmployee);

           
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _employeerepository.GetByIdAsync(id);
            if (employee != null)
            {
                await _employeerepository.DeleteAsync(id);
            }
        }


        public async Task<List<spParentAndChildrenDTO>> GetspEmployeesByUserIdAsync(int userId, int orgId)
        {
            var employees = _employeerepository.GetEmployeesByUserIdAsync(userId, orgId);

            if (employees == null)
            {
                return null;
            }

            var Employees = _mappingProfile.Map<List<spParentAndChildrenDTO>>(employees).ToList();

            return Employees;
        }

        public async Task<bool> ChangePasswordAsync(ChangePasswordDTO changePassword)
        {
            return await _employeerepository.ChangePasswordAsync(
                changePassword.UserName,
                changePassword.CurrentPassword,
                changePassword.NewPassword
            );
        }


        public async Task<List<spParentDTO>> GetspParentOfUsersAsync()
        {
            var spParents = _employeerepository.GetspParentOfUsersByOrgIdAsync();

            if (spParents == null)
            {
                return null;
            }

            var SpParents = _mappingProfile.Map<List<spParentDTO>>(spParents).ToList();

            return SpParents;
        }

        public async Task<List<spGetActivitiesResponseDTO>> GetspActivitiesAsync(spGetActivitiesRequestDTO activities)
        {
            try
            {
                var spActivities = _employeerepository.GetspActivitiesByFiltersAsync(activities);

                if (spActivities == null)
                {
                    return null;
                }

                var spActivitiesDto = _mappingProfile.Map<List<spGetActivitiesResponseDTO>>(spActivities).ToList();

                return spActivitiesDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<spGetTimelineResponseDTO>> GetTimelineAsync(spGetTimelineRequestDTO timeline)
        {
            try
            {
                var timelines = _employeerepository.GetspTimelineByFilterAsync(timeline);

                if (timelines == null)
                {
                    return null;
                }

                var spTimelineDtos = _mappingProfile.Map<List<spGetTimelineResponseDTO>>(timelines).ToList();

                return spTimelineDtos;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

    }
}



