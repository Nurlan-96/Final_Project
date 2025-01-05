using Domain.Exceptions;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Reporistories;
using FinalProject.Infrastructure.DAL;
using IdentityModule.Queries;
using Job.Module.Commands;

namespace Job.Module.Service
{
    public class JobService(AppDbContext context, IJobRepository jobRepo, IUserQueries userQueries, ICompanyRepository companyRepository) : IJobService
    {
        private readonly AppDbContext _context = context;
        private readonly IJobRepository _jobRepo = jobRepo;
        private readonly IUserQueries _userQueries = userQueries;
        private readonly ICompanyRepository _companyRepo = companyRepository;
        public async Task<bool> CreateJobPost(CreateJobCommand command)
        {
            var data = await _companyRepo.GetWhere(x => x.Id == command.CompanyId)
            ?? throw new EntityNotFoundException<CompanyEntity>();

            JobPostEntity newJobPost = new()
            {
                Address = command.Address,
                Description = command.Description,
                Name = command.Name,
                Requirements = command.Requirements,
                Salary = command.Salary,
                CategoryId = command.CategoryId,
                Education = command.Education,
                Experience = command.Experience,
                EmploymentType = command.EmploymentType,
                ExpirationDate = DateTime.SpecifyKind(command.ExpirationDate, DateTimeKind.Utc),
                City = command.City,
                CompanyId = command.CompanyId,
                IsDeleted = false,
            };
            await _jobRepo.AddAsync(newJobPost);
            await _jobRepo.UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateJobPost(UpdateJobCommand command)
        {
            var data = await _jobRepo.GetWhere(x => x.Id == command.JobId)
                ?? throw new EntityNotFoundException<JobPostEntity>();
            #region update
            data.UpdatedDate = DateTime.UtcNow;
            data.ExpirationDate = command.ExpirationDate;
            data.City = command.City;
            data.CompanyId = command.CompanyId;
            data.CategoryId = command.CategoryId;
            data.Address = command.Address;
            data.Description = command.Description;
            data.Education = command.Education;
            data.Experience = command.Experience;
            data.EmploymentType = command.EmploymentType;
            data.Salary = command.Salary;
            #endregion
            _jobRepo.Update(data);
            await _jobRepo.UnitOfWork.SaveChangesAsync();
            return true;
        } 
        public async Task<bool> ArchiveJobPost(UpdateJobCommand command)
        {
            var data = await _jobRepo.GetWhere(x => x.Id == command.JobId)
                ?? throw new EntityNotFoundException<JobPostEntity>();
            #region update
            data.UpdatedDate = DateTime.UtcNow;
            data.IsDeleted = command.IsDeleted;
            #endregion
            _jobRepo.Update(data);
            await _jobRepo.UnitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteJobPost(int jobPostId)
        {
            var data = await _jobRepo.GetWhere(x => x.Id == jobPostId)
                ?? throw new EntityNotFoundException<JobPostEntity>();

            _jobRepo.Delete(data);
            await _jobRepo.UnitOfWork.SaveChangesAsync();
            return true;
        }
        public IEnumerable<JobPostEntity> SearchJobs(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return _context.JobPosts.ToList();
            }

            return _context.JobPosts
                           .Where(j => j.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                       j.Description.Contains(query, StringComparison.OrdinalIgnoreCase))
                           .ToList();
        }
    }
}
