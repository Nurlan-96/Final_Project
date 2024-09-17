using Application.Usecases;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Reporistories;
using FinalProject.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Application.Usecase
{
    public class UserRepository(AppDbContext context) : Repository<UserEntity>, IUserRepository
    {
        public sealed override DbContext Context { get; protected set; } = context;
    }
}
