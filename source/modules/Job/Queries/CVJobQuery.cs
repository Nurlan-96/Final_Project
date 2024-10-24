using Application.Response;
using AutoMapper;
using Domain.Exceptions;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Reporistories;
using Job.Module.Responses;

namespace Job.Module.Queries
{
    public class CVJobQuery(ICVJobRepository jobRepo, IMapper mapper) : ICVJobQuery
    {
        private readonly ICVJobRepository _jobRepo = jobRepo;
        private readonly IMapper _mapper = mapper;
        public async Task<Pagination<CVJobEntity>> GetAllCVJobs(int page, int size)
        {
            var data = await _jobRepo.GetAllAsync();
            var paginated = new Pagination<CVJobEntity>(data, page, size);
            return paginated;
        }
       
        public async Task<CVJobResponse> GetCVJobById(int id)
        {
            var data = await _jobRepo.GetAsync(x => x.Id == id)
                ?? throw new EntityNotFoundException<CVJobEntity>();
            var mapped = _mapper.Map<CVJobResponse>(data);
            return mapped;
        }        
    }
}
