using Application.Response;
using FinalProject.Domain.Entities;
using Job.Module.Responses;

namespace Job.Module
{
    public interface IJobQuery
    {
        Task<Pagination<JobPostEntity>> GetAllJobs(int page, int size);
        Task<JobPostResponse> GetJobById(int id);
        Task<JobPostEntity> GetJobByCategory(int categoryId);
    }
}
