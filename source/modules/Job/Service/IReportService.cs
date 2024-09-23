using Job.Module.Command;

namespace Job.Module.Service
{
    public interface IReportService
    {
        public Task<bool> CreateReport(CreateReportCommand command);
        public Task<bool> ArchiveReport(UpdateReportCommand command);
        public Task<bool> DeleteReport(int reportId);
    }
}
