using AutoMapper;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Entities.RoleAggregate;
using IdentityModule.Response;

namespace IdentityModule.Profiles
{
    public class UserProfile : Profile
	{
        public UserProfile()
        {
            CreateMap<UserEntity, UserResponse>();
            CreateMap<Role, RoleResponse>();
            CreateMap<RoleResponse, Role>();
        }
    }
}
