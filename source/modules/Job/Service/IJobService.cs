using FinalProject.Domain.Entities;
using Job.Module.Commands;
using System.Runtime.CompilerServices;

namespace Job.Module.Service
{
    public interface IJobService
    {
        public Task<bool> CreateJobPost(CreateJobCommand command);
        public Task<bool> UpdateJobPost(UpdateJobCommand command);
        public Task<bool> ArchiveJobPost(UpdateJobCommand command);
        public Task<bool> DeleteJobPost(int jobPostId);
        public IEnumerable<JobPostEntity> SearchJobs(string query);
    }
}
