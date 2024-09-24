using Company.Module.Commands;
using Microsoft.AspNetCore.Http;

namespace Company.Module.Services
{
    public interface ICompanyService
    {
        public Task<bool> CreateCompany(CreateCompanyCommand command);
        public Task<bool> UpdateCompany(UpdateCompanyCommand command);
        public Task<bool> DeleteCompany(int companyId);
        public Task<bool> ArchiveCompany(UpdateCompanyCommand command);

    }
}
