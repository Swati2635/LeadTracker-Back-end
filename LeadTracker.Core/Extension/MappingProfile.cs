using AutoMapper;
using LeadTracker.API;
using LeadTracker.Core.DTO;
using LeadTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Core.Extension
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<LoginDTO, Employee>().ReverseMap();

            CreateMap<OrganisationDTO, Organisation>().ReverseMap();

            CreateMap<AddressDTO, Address>().ReverseMap();

            CreateMap<BranchDTO, Branch>().ReverseMap();

            CreateMap<CodeDTO, Code>().ReverseMap();

            CreateMap<DocumentDTO, Document>().ReverseMap();    

            CreateMap<EmployeeDTO, Employee>().ReverseMap();

            CreateMap<PermissionDTO, Permission>().ReverseMap();

            CreateMap<RolePermissionDTO, RolePermission>().ReverseMap();

            CreateMap<RoleDTO, Role>().ReverseMap();

            CreateMap<BookingDTO, Booking>().ReverseMap();

            CreateMap<LeadDTO, Lead>().ReverseMap();

            CreateMap<LeadSourceGetDTO, LeadSource>().ReverseMap();

            CreateMap<LocationDTO, Location>().ReverseMap();

            CreateMap<ProjectDTO, Project>().ReverseMap();

            CreateMap<ProjectDetailDTO, ProjectDetail>().ReverseMap();

            CreateMap<TrackerDTO, Tracker>().ReverseMap();

            CreateMap<UserLocationDTO, UserLocation>().ReverseMap();

            CreateMap<UserLocationResponseDTO, UserLocation>().ReverseMap();

            CreateMap<ZoneDTO, Zone>().ReverseMap();

            CreateMap<WorkFlowDTO, WorkFlow>().ReverseMap();

            //CreateMap<WorkFlowStepDTO, WorkFlowStep>().ForMember(src => src.Id, opts => opts.MapFrom(dest => dest.WorkFlowStepId)).ReverseMap();

            CreateMap<WorkFlowStepDTO, WorkFlowStep>().ReverseMap();
            CreateMap<AttendanceDTO, Attendance>().ReverseMap();





        }

    }
}
