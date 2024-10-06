using Application.Response;
using AutoMapper;
using Domain.Exceptions;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Reporistories;
using Job.Module.Responses;
using Microsoft.EntityFrameworkCore;

namespace Job.Module.Queries
{
    public class JobQuery(IJobRepository jobRepo, IMapper mapper) : IJobQuery
    {
        private readonly IJobRepository _jobRepo = jobRepo;
        private readonly IMapper _mapper = mapper;
        public async Task<Pagination<JobPostEntity>> GetAllJobs(int page, int size)
        {
            var data = await _jobRepo.GetAllAsync();
            var paginated = new Pagination<JobPostEntity>(data, page, size);
            return paginated;
        }
       
        public async Task<JobPostResponse> GetJobById(int id)
        {
            var data = await _jobRepo.GetAsync(x => x.Id == id,x=> x.Category, x=>x.Company)
                ?? throw new EntityNotFoundException<JobPostEntity>();
            var mapped = _mapper.Map<JobPostResponse>(data);
            return mapped;
        }        
        public async Task<JobPostEntity> GetJobByCategory(int categoryId)
        {
            return await _jobRepo.GetWhere(x => x.CategoryId == categoryId)
                ?? throw new EntityNotFoundException<JobPostEntity>();
        }
    }
}
