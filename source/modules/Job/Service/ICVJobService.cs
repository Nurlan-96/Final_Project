using Job.Module.Commands;

namespace Job.Module.Service
{
    public interface ICVJobService
    {
        public Task<bool> CreateCVJob(CreateCVJobCommand command, string token);
        public Task<bool> UpdateCVJob(UpdateCVJobCommand command);
        public Task<bool> DeleteCVJob(int jobPostId);
    }
}
