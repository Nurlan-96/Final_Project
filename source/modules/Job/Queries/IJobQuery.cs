using Application.Response;
using FinalProject.Domain.Entities;

namespace Job.Module
{
    public interface IJobQuery
    {
        Task<Pagination<JobPost>> GetAllJobs(int page, int size);
        Task<JobPost> GetJobById(int id);
    }
}
