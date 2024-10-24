using Application.Response;
using FinalProject.Domain.Entities;
using Job.Module.Responses;

namespace Job.Module
{
    public interface ICVJobQuery
    {
        Task<Pagination<CVJobEntity>> GetAllCVJobs(int page, int size);
        Task<CVJobResponse> GetCVJobById(int id);
    }
}
