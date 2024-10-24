using AutoMapper;
using Company.Module.Responses;
using FinalProject.Domain.Entities;
using Job.Module.Responses;

namespace Job.Module.Profiles
{
    public class CVProfile : Profile
    {
        public CVProfile()
        {
            CreateMap<CVEntity, CVResponse>();
        }
    }
}
