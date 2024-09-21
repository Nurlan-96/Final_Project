using Job.Module.Command;
using Microsoft.AspNetCore.Http;

namespace Job.Module.Service
{
    public interface ICompanyService
    {
        public Task<bool> CreateCompany(CreateCompanyCommand command);
        public Task<bool> UpdateCompany(UpdateCompanyCommand command);
        public Task<bool> DeleteCompany(int companyId);
        public Task<bool> ArchiveCompany(UpdateCompanyCommand command);

    }
}
