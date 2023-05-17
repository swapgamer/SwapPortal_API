using AutoMapper;
using SwapPortal_API.BLL.DTO;
using SwapPortal_API.DAL.Entities;

namespace SwapPortal_API.Infrastructure
{
    public class AutoMapperProfiles : Profile

    {
        public AutoMapperProfiles()
        {
            CreateMap<AddUserRequestDTO, User>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserRole, UserRoleDTO>().ReverseMap();
            CreateMap<UpdateUserRequestDTO, User>().ReverseMap();
            CreateMap<AddJobListingRequestDTO, JobListing>().ReverseMap();
            CreateMap<JobListing, JobListingDTO>().ReverseMap();
            CreateMap<UpdateJobListingDTO, JobListing>().ReverseMap();
            CreateMap<AddAplicationRequestDTO, Application>().ReverseMap();
            CreateMap<Application, ApplicationDTO>().ReverseMap();
        }
    }
}
