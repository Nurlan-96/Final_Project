using Application.Response;
using Domain.Exceptions;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Reporistories;

namespace Job.Module.Queries
{
    public class JobQuery(IJobRepository jobRepo) : IJobQuery
    {
        private readonly IJobRepository _jobRepo = jobRepo;
        public async Task<Pagination<JobPost>> GetAllJobs(int page, int size)
        {
            var data = await _jobRepo.GetAllAsync();
            var paginated = new Pagination<JobPost>(data, page, size);
            return paginated;
        }
       
        public async Task<JobPost> GetJobById(int id)
        {
            return await _jobRepo.GetWhere(x => x.Id == id)
                ?? throw new EntityNotFoundException<JobPost>();
        }
    }
}
