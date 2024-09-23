using Domain.Exceptions;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Reporistories;
using Job.Module.Command;
using Microsoft.AspNetCore.Http;

namespace Job.Module.Service
{
    public class ReportService(IReportRepository reportRepo) : IReportService
    {
        private readonly IReportRepository _reportRepo = reportRepo;

        public async Task<bool> ArchiveReport(UpdateReportCommand command)
        {
            var data = await _reportRepo.GetWhere(x => x.Id == command.ReportId)
            ?? throw new EntityNotFoundException<JobPost>();
            #region update
            data.UpdatedDate = DateTime.UtcNow;
            data.IsDeleted = command.IsDeleted;
            #endregion
            _reportRepo.Update(data);
            await _reportRepo.UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateReport(CreateReportCommand command)
        {
            Report newReport = new()
            {
                Reason = command.Reason,
                UserId = command.UserId,
                JobPostId = command.JobPostId,
                CreatedDate = DateTime.UtcNow,
            };
            await _reportRepo.AddAsync(newReport);
            await _reportRepo.UnitOfWork.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteReport(int reportId)
        {
            var data = await _reportRepo.GetWhere(x => x.Id == reportId)
            ?? throw new EntityNotFoundException<Report>();

            _reportRepo.Delete(data);
            await _reportRepo.UnitOfWork.SaveChangesAsync();
            return true;
        }

    }
}

