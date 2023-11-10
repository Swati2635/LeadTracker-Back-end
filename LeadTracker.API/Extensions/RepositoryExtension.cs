using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure;
using LeadTracker.Infrastructure.IRepository;
using LeadTracker.Infrastructure.Repository;

namespace LeadTracker.API.Extensions
{
    public static class RepositoryExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddScoped<IBranchRepository, BranchRepository>();

            services.AddScoped<ICodeRepository, CodeRepository>();

            services.AddScoped<IDocumentRepository, DocumentRepository>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IEmployeeRoleRepository, EmployeeRoleRepository>();

            services.AddScoped<IOrganisationRepository, OrganisationRepository>();

            services.AddScoped<IPermissionRepository, PermissionRepository>();

            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();

            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddScoped<IBookingRepository, BookingRepository>();

            services.AddScoped<ILeadRepository, LeadRepository>();

            services.AddScoped<ILeadSourceRepository, LeadSourceRepository>();

            services.AddScoped<ILocationRepository, LocationRepository>();

            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddScoped<IProjectDetailRepository, ProjectDetailRepository>();

            services.AddScoped<ITrackerRepository, TrackerRepository>();

            services.AddScoped<IUserLocationRepository, UserLocationRepository>();

            services.AddScoped<IZoneRepository, ZoneRepository>();

            services.AddScoped<IWorkFlowRepository, WorkFlowRepository>();

            services.AddScoped<IWorkFlowStepRepository, WorkFlowStepRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
        }
    }
}
