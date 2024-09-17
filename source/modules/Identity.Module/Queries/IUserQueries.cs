using Application.Response;
using FinalProject.Domain.Entities;
using IdentityModule.Response;

namespace IdentityModule.Queries
{
    public interface IUserQueries
	{
		Task<Pagination<UserResponse>> GetAllUserResponses(int page = 1, int size = 10);
		/// <summary>
		/// Find Users using unique email address.
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		Task<UserEntity> FindAsync(string email);
		/// <summary>
		/// Find Users using unique GUID.
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		Task<UserEntity> FindAsync(int Id);
		Task<UserEntity> FindByRefreshToken(string refreshToken);
		Task<UserResponse> GetUserResponseAsync(int? userId);
	}
}