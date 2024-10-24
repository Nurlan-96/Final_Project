using Application.Response;
using AutoMapper;
using Domain.Exceptions;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Reporistories;
using IdentityModule.Queries;
using Infrastructure.Identity;
using Job.Module.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Job.Module.Queries
{
    public class CVQuery(ICVRepository cvRepo, IMapper mapper, IClaimsManager claimsManager, IUserQueries userQueries) : ICVQuery
    {
        private readonly ICVRepository _cvRepo = cvRepo;
        private readonly IMapper _mapper = mapper;
        private readonly IClaimsManager _claimsManager = claimsManager;
        private readonly IUserQueries _userQueries = userQueries;
        public async Task<Pagination<CVEntity>> GetAllCV(int page, int size)
        {
            var data = await _cvRepo.GetAllAsync();
            var paginated = new Pagination<CVEntity>(data, page, size);
            return paginated;
        }

        public async Task<CVResponse> GetCVByUserId(string token)
        {
            var user = await _userQueries.FindByRefreshToken(token)
                ?? throw new EntityNotFoundException<UserEntity>();

            var data = await _cvRepo.GetAsync(x => x.UserId == user.Id)
                ?? throw new EntityNotFoundException<CVEntity>();

            var mapped = _mapper.Map<CVResponse>(data);
            return mapped;
        }

    }
}
