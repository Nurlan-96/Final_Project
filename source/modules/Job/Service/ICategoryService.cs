using Company.Module.Commands;
using FinalProject.Domain.Entities;
using Job.Module.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Job.Module.Service
{
    public interface ICategoryService
    {
        public Task<bool> CreateCategory(CreateCategoryCommand command);
        public Task<bool> UpdateCategory(UpdateCategoryCommand command);
        public Task<bool> DeleteCategory(int categoryId);
        public IEnumerable<CategoryEntity> SearchCategories(string query);

    }
}
