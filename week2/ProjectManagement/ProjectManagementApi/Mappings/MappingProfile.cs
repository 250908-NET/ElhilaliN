using AutoMapper;
using ProjectManagementApi.DTOs;
using ProjectManagementApi.Models;

namespace ProjectManagementApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User mappings
            CreateMap<UserCreateDTO, User>();
            CreateMap<User, UserReadDTO>()
                .ForMember(dest => dest.AssignedIssueIds,
                           opt => opt.MapFrom(src => src.AssignedIssues.Select(i => i.Id)));

            // Project mappings
            CreateMap<ProjectCreateDTO, Project>();
            CreateMap<Project, ProjectReadDTO>()
                .ForMember(dest => dest.IssueIds,
                           opt => opt.MapFrom(src => src.Issues.Select(i => i.Id)));

            // Issue mappings
            CreateMap<IssueCreateDTO, Issue>();
            CreateMap<Issue, IssueReadDTO>();
        }
    }
}
