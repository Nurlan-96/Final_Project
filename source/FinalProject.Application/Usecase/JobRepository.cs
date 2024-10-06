using Application.Usecases;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Reporistories;
using FinalProject.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Application.Usecase
{
    public class JobRepository(AppDbContext context) : Repository<JobPostEntity>, IJobRepository
    {
        public sealed override DbContext Context { get; protected set; } = context;
    }
}
