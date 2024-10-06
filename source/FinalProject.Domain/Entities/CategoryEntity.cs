using FinalProject.SharedKernel.Domain.Seedwork;

namespace FinalProject.Domain.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }
        private readonly List<JobPostEntity> _jobposts;
        public IReadOnlyCollection<JobPostEntity> JobPosts => _jobposts;
        public CategoryEntity()
        {
            _jobposts = [];
        }
    }
}
