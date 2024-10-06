using Domain.Exceptions;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Reporistories;
using Job.Module.Commands;

namespace Job.Module.Service
{
    public class JobService(IJobRepository jobRepo) : IJobService
    {
        private readonly IJobRepository _jobRepo = jobRepo;
        public async Task<bool> CreateJobPost(CreateJobCommand command)
        {   
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
                ExpirationDate = command.ExpirationDate,
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
    }
}
