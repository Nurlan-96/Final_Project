using Company.Module.Commands;
using FinalProject.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Company.Module.Services
{
    public interface ICompanyService
    {
        public Task<bool> CreateCompany(CreateCompanyCommand command, string token);
        public Task<bool> UpdateCompany(UpdateCompanyCommand command);
        public Task<bool> DeleteCompany(int companyId);
        public Task<bool> ArchiveCompany(UpdateCompanyCommand command);
        public IEnumerable<CompanyEntity> SearchCompanies(string query);

    }
}
