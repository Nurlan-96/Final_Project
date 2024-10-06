using Application.Response;
using FinalProject.Domain.Entities;

namespace Job.Module.Queries
{
    public interface ICategoryQuery
    {
        Task<Pagination<CategoryEntity>> GetAllCategories(int page, int size);
        Task<CategoryEntity> GetCategoryById(int id);
    }
}
