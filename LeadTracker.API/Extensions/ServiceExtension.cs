using LeadTracker.Application.IService;
using LeadTracker.Application.Service;
using LeadTracker.BusinessLayer.IService;
using LeadTracker.BusinessLayer.Service;
using LeadTracker.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace LeadTracker.API.Extensions
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {

            services.AddScoped<IOrgnisationService, OrganisationService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<ICodeService, CodeService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRoleService, EmployeeRoleService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IRolePermissionService, RolePermissionService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ILeadService, LeadService>();
            services.AddScoped<ILeadSourceService, LeadSourceService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProjectDetailService, ProjectDetailService>();
            services.AddScoped<ITrackerService, TrackerService>();
            services.AddScoped<IUserLocationService, UserLocationService>();
            services.AddScoped<IWorkFlowService, WorkFlowService>();
            services.AddScoped<IWorkFlowStepService, WorkFlowStepService>();
            services.AddScoped<IZoneService, ZoneService>();
            services.AddScoped<IAttendanceService, AttendanceService>();


        }
        
    }
}
