using Domain.Exceptions;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Reporistories;
using FinalProject.Infrastructure.DAL;
using Job.Module.Commands;
using Microsoft.EntityFrameworkCore;

namespace Job.Module.Service
{
    public class CategoryService(ICategoryRepository categoryRepo, AppDbContext context) : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo = categoryRepo;
        private readonly AppDbContext _context = context;

        public async Task<bool> CreateCategory(CreateCategoryCommand command)
        {
            CategoryEntity newCategory = new()
            {
                Name = command.Name,
            };
            await _categoryRepo.AddAsync(newCategory);
            await _categoryRepo.UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            var data = await _categoryRepo.GetWhere(x => x.Id == categoryId)
            ?? throw new EntityNotFoundException<JobPostEntity>();
            _categoryRepo.Delete(data);
            await _categoryRepo.UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCategory(UpdateCategoryCommand command)
        {
            var data = await _categoryRepo.GetWhere(x => x.Id == command.CategoryId)
            ?? throw new EntityNotFoundException<JobPostEntity>();
            data.UpdatedDate = DateTime.UtcNow;
            data.Name = command.Name;
            _categoryRepo.Update(data);
            await _categoryRepo.UnitOfWork.SaveChangesAsync();
            return true;
        }
        public IEnumerable<CategoryEntity> SearchCategories(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return _context.Categories.ToList();
            }

            return _context.Categories
                           .Where(c => c.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
                           .ToList();
        }
    }
}
