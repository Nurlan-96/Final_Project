using Application.Response;
using Domain.Exceptions;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Reporistories;

namespace Job.Module.Queries
{
    public class CategoryQuery(ICategoryRepository catRepo) : ICategoryQuery
    {
        private readonly ICategoryRepository _catRepo = catRepo;
        public async Task<Pagination<Category>> GetAllCategories(int page, int size)
        {
            var data = await _catRepo.GetAllAsync();
            var paginated = new Pagination<Category>(data, page, size);
            return paginated;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _catRepo.GetWhere(x => x.Id == id) 
                ?? throw new EntityNotFoundException<Category>();
        }
    }
}
