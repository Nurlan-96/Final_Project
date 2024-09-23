using Application.Response;
using FinalProject.Domain.Entities;

namespace Job.Module.Queries
{
    public interface ICategoryQuery
    {
        Task<Pagination<Category>> GetAllCategories(int page, int size);
        Task<Category> GetCategoryById(int id);
    }
}
