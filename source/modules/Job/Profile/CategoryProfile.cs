using AutoMapper;
using FinalProject.Domain.Entities;
using Job.Module.Responses;

namespace Job.Module.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<JobPostEntity, JobPostResponse>();
            CreateMap<CategoryEntity, CategoryResponse>();
        }
    }
}
