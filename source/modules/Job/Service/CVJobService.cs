using Domain.Exceptions;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Reporistories;
using FinalProject.Infrastructure.DAL;
using IdentityModule.Queries;
using Job.Module.Commands;

namespace Job.Module.Service
{
    public class CVJobService(AppDbContext context, ICVJobRepository jobRepo, ICVRepository cvRepository, IUserQueries userQueries) : ICVJobService
    {
        private readonly AppDbContext _context = context;
        private readonly ICVJobRepository _jobRepo = jobRepo;
        private readonly ICVRepository _cvRepository = cvRepository;
        private readonly IUserQueries _userQueries = userQueries;
        public async Task<bool> CreateCVJob(CreateCVJobCommand command, string token)
        {
            var user = await _userQueries.FindByRefreshToken(token)
            ?? throw new EntityNotFoundException<UserEntity>();
            var cv = await _cvRepository.GetAsync(c => c.Id == user.CVEntityId);
            CVJobEntity newJob = new()
            {
                Name = command.Name,
                Description = command.Description,
                CompanyName = command.CompanyName,
                StartDate = command.StartDate,
                EndDate = command.EndDate,
                City = command.City,
                CVEntityId = cv.Id,
            };
            await _jobRepo.AddAsync(newJob);
            await _jobRepo.UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCVJob(UpdateCVJobCommand command)
        {
            var data = await _jobRepo.GetWhere(x => x.Id == command.JobId)
                ?? throw new EntityNotFoundException<CVJobEntity>();
            #region update
            data.UpdatedDate = DateTime.UtcNow;
            data.Name = command.Name;
            data.City = command.City;
            data.StartDate = command.StartDate;
            data.EndDate = command.EndDate;
            data.CompanyName = command.CompanyName;
            data.Description = command.Description;
            #endregion
            _jobRepo.Update(data);
            await _jobRepo.UnitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteCVJob(int jobPostId)
        {
            var data = await _jobRepo.GetWhere(x => x.Id == jobPostId)
                ?? throw new EntityNotFoundException<CVJobEntity>();
            _jobRepo.Delete(data);
            await _jobRepo.UnitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
