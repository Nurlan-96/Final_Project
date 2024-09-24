using Application.Usecases;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Reporistories;
using FinalProject.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Application.Usecase
{
    public class CompanyRepository(AppDbContext context) : Repository<CompanyEntity>, ICompanyRepository
    {
        public sealed override DbContext Context { get; protected set; } = context;
    }
}
