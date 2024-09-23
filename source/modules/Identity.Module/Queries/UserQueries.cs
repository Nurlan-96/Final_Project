using Application.Response;
using AutoMapper;
using Domain.Entities.RoleAggergate;
using FinalProject.Domain.Entities;
using FinalProject.Infrastructure.DAL;
using IdentityModule.Response;
using Microsoft.EntityFrameworkCore;

namespace IdentityModule.Queries
{
    public class UserQueries(AppDbContext context, IMapper mapper) : IUserQueries
	{
		private readonly AppDbContext _context = context;
		private readonly IMapper _mapper = mapper;

		public async Task<UserEntity> FindAsync(int Id)
		{
			return await _context
				.Users
				.Include(u => u.Role)
				.FirstOrDefaultAsync(u => u.Id == Id);
		}

		public async Task<UserEntity> FindAsync(string email)
		{
			return await _context
				.Users
				.Include(u => u.Role)
				.FirstOrDefaultAsync(u => u.Email == email);
		}

		public async Task<UserEntity> FindByRefreshToken(string refreshToken)
		{
			return await _context
				.Users
				.Include(u => u.Role)
				.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
		}

		public async Task<Pagination<UserResponse>> GetAllUserResponses(int page = 1, int size = 10)
		{
			var data = _context
				.Users
				.Where(u => u.RoleId != RoleParameter.SuperAdmin.Id)
				.Include(u => u.Role)
				.AsNoTracking()
				.AsEnumerable();

            var mapped = _mapper.Map<IEnumerable<UserResponse>>(data);
            return new Pagination<UserResponse>(mapped.ToList(), page, size);
        }

        public async Task<UserResponse> GetUserResponseAsync(int? userId)
        {
            UserEntity? user = await _context.Users
                .Include(u => u.Role)
               .AsNoTracking()
               .FirstOrDefaultAsync(u => u.Id == userId);

            return _mapper.Map<UserResponse>(user);
        }
    }
} 