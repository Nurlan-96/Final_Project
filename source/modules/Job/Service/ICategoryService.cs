using Job.Module.Command;

namespace Job.Module.Service
{
    public interface ICategoryService
    {
        public Task<bool> CreateCategory(CreateCategoryCommand command);
        public Task<bool> UpdateCategory(UpdateCategoryCommand command);
        public Task<bool> DeleteCategory(int categoryId);
    }
}
