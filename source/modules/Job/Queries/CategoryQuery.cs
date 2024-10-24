using Application.Response;
using Domain.Exceptions;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Reporistories;
using FinalProject.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Job.Module.Queries
{
    public class CategoryQuery(ICategoryRepository catRepo) : ICategoryQuery
    {
        private readonly ICategoryRepository _catRepo = catRepo;
        public async Task<Pagination<CategoryEntity>> GetAllCategories(int page, int size)
        {
            var data = await _catRepo.GetAllAsync();
            var paginated = new Pagination<CategoryEntity>(data, page, size);
            return paginated;
        }

        public async Task<CategoryEntity> GetCategoryById(int id)
        {
            return await _catRepo.GetWhere(x => x.Id == id) 
                ?? throw new EntityNotFoundException<CategoryEntity>();
        }
    }
}
