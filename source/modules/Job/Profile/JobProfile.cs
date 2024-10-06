using AutoMapper;
using Company.Module.Responses;
using FinalProject.Domain.Entities;
using Job.Module.Responses;

namespace Job.Module.Profiles
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<JobPostEntity, JobPostResponse>();
            CreateMap<CompanyEntity, CompanyResponse>();
        }
    }
}
