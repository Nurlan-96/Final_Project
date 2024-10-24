using Domain.Exceptions;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Reporistories;
using FinalProject.Infrastructure.DAL;
using IdentityModule.Queries;
using Job.Module.Commands;
using Newtonsoft.Json.Linq;

namespace Job.Module.Service
{
    public class CVService(AppDbContext context, ICVRepository jobRepo, IUserQueries userQueries) : ICVService
    {
        private readonly AppDbContext _context = context;
        private readonly ICVRepository _cvRepo = jobRepo;
        private readonly IUserQueries _userQueries = userQueries;
        public async Task<bool> CreateCV(CreateCVCommand command, string token)
        {
            var user = await _userQueries.FindByRefreshToken(token)
            ?? throw new EntityNotFoundException<UserEntity>();

            CVEntity newCV = new()
            {
                Fullname = user.Fullname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                AboutMe = command.AboutMe,
                Address = command.Address,
                City = command.City,
                Education = command.Education,
                ExpectedSalary = command.ExpectedSalary,
                Experience = command.Experience,
                CreatedDate = DateTime.UtcNow,
            };
            await _cvRepo.AddAsync(newCV);
            await _cvRepo.UnitOfWork.SaveChangesAsync();

            return true;
        }


        public async Task<bool> UpdateCV(UpdateCVCommand command)
        {
            var data = await _cvRepo.GetWhere(x => x.Id == command.CVId)
                ?? throw new EntityNotFoundException<CVEntity>();
            #region update
            data.UpdatedDate = DateTime.UtcNow;
            data.Fullname = command.Fullname;
            data.Email = command.Email;
            data.PhoneNumber = command.PhoneNumber;
            data.AboutMe = command.AboutMe;
            data.Address = command.Address;
            data.City = command.City;
            data.Education = command.Education;
            data.ExpectedSalary = command.ExpectedSalary;
            data.Experience = command.Experience;
            #endregion
            _cvRepo.Update(data);
            await _cvRepo.UnitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteCV(int cvId)
        {
            var data = await _cvRepo.GetWhere(x => x.Id == cvId)
                ?? throw new EntityNotFoundException<CVEntity>();
            _cvRepo.Delete(data);
            await _cvRepo.UnitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
