using Job.Module.Commands;

namespace Job.Module.Service
{
    public interface ICVService
    {
        public Task<bool> CreateCV(CreateCVCommand command, string token);
        public Task<bool> UpdateCV(UpdateCVCommand command);
        public Task<bool> DeleteCV(int cvId);
    }
}
