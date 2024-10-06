using AutoMapper;
using Company.Module.Responses;
using FinalProject.Domain.Entities;

namespace Company.Module.Profiles
{
    public class CompanyProfile : Profile

    {
        public CompanyProfile()
        {
            CreateMap<CompanyEntity, CompanyResponse>();
        }
    }
}
