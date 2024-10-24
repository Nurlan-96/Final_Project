using Company.Module.Commands;
using Domain.Exceptions;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Reporistories;
using FinalProject.Infrastructure.DAL;
using FinalProject.SharedKernel.Domain.Extensions;
using IdentityModule.Queries;
using Microsoft.AspNetCore.Http;

namespace Company.Module.Services
{
    public class CompanyService(ICompanyRepository companyRepo, IHttpContextAccessor httpContextAccessor, AppDbContext context, IUserQueries userQueries) : ICompanyService
    {
        private readonly ICompanyRepository _companyRepo = companyRepo;
        private readonly AppDbContext _context = context;
        private readonly IHttpContextAccessor _contextAccessor = httpContextAccessor;
        private readonly IUserQueries _userQueries = userQueries;

        public async Task<bool> ArchiveCompany(UpdateCompanyCommand command)
        {
            var data = await _companyRepo.GetWhere(x => x.Id == command.CompanyId)
            ?? throw new EntityNotFoundException<CompanyEntity>();
            #region update
            data.UpdatedDate = DateTime.UtcNow;
            data.IsDeleted = command.IsDeleted;
            #endregion
            _companyRepo.Update(data);
            await _companyRepo.UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CreateCompany(CreateCompanyCommand command, string token)
        {
            var user = await _userQueries.FindByRefreshToken(token)
             ?? throw new EntityNotFoundException<UserEntity>();

            string folderName = "companies";
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", folderName);
            long maxFileSize = 1 * 1024 * 1024;

            string uploadedImageUrl = string.Empty;

            if (command.Image != null)
            {
                try
                {
                    uploadedImageUrl = await command.Image.UploadImageAsync(uploadPath, maxFileSize, httpContextAccessor);
                }
                catch (ArgumentException ex)
                {
                    throw new Exception("Image upload failed: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while uploading the image: " + ex.Message);
                }
            }

            CompanyEntity newCompany = new()
            {
                Address = command.Address,
                Description = command.Description,
                Name = command.Name,
                IsDeleted = false,
                CreatedDate = DateTime.UtcNow,
                PhoneNumber = command.PhoneNumber,
                Email = command.Email,
                Image = uploadedImageUrl,
                UserId = user.Id,
            };

            await _companyRepo.AddAsync(newCompany);
            await _companyRepo.UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCompany(int companyId)
        {
            var data = await _companyRepo.GetWhere(x => x.Id == companyId)
                ?? throw new EntityNotFoundException<CompanyEntity>();
            string folderName = "companies";
            data.Image.DeleteImage(folderName);
            _companyRepo.Delete(data);
            await _companyRepo.UnitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateCompany(UpdateCompanyCommand command)
        {
            var data = await _companyRepo.GetWhere(x => x.Id == command.CompanyId)
            ?? throw new EntityNotFoundException<CompanyEntity>();
            string folderName = "companies";
            data.Image.DeleteImage(folderName);
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", folderName);
            long maxFileSize = 1 * 1024 * 1024;

            string uploadedImageUrl = null;

            if (command.Image != null)
            {
                try
                {
                    uploadedImageUrl = await command.Image.UploadImageAsync(uploadPath, maxFileSize, httpContextAccessor);
                }
                catch (ArgumentException ex)
                {
                    throw new Exception("Image upload failed: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while uploading the image: " + ex.Message);
                }
            }
            var updatedData = await _companyRepo.GetWhere(x => x.Id == command.CompanyId)
            ?? throw new EntityNotFoundException<JobPostEntity>();
            #region update
            data.UpdatedDate = DateTime.UtcNow;
            data.Address = command.Address;
            data.Description = command.Description;
            data.Name = command.Name;
            data.Email = command.Email;
            data.PhoneNumber = command.PhoneNumber;
            data.Image = uploadedImageUrl;
            #endregion
            _companyRepo.Update(updatedData);
            await _companyRepo.UnitOfWork.SaveChangesAsync();
            return true;
        }
        public IEnumerable<CompanyEntity> SearchCompanies(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return _context.Companies.ToList();
            }

            return _context.Companies
                           .Where(co => co.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                        co.Description.Contains(query, StringComparison.OrdinalIgnoreCase))
                           .ToList();
        }
    }
}
