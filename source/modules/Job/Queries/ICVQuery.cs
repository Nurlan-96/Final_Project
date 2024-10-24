using Application.Response;
using FinalProject.Domain.Entities;
using Job.Module.Responses;

namespace Job.Module
{
    public interface ICVQuery
    {
        Task<Pagination<CVEntity>> GetAllCV(int page, int size);
        Task<CVResponse> GetCVByUserId(string token);
    }
}
