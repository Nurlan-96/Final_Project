using FinalProject.SharedKernel.Domain.Seedwork;

namespace FinalProject.Domain.Entities
{
    public class UserAppliedJob : BaseEntity
    {
        public int? UserId { get; set; }
        public UserEntity User { get; set; }

        private readonly List<JobPostEntity> _jobPosts;
        public IReadOnlyCollection<JobPostEntity> JobPosts => _jobPosts;
        public UserAppliedJob()
        {
            _jobPosts = new List<JobPostEntity>();
        }

        public void AddJobPost(JobPostEntity jobPost)
        {
            if (!_jobPosts.Contains(jobPost))
            {
                _jobPosts.Add(jobPost);
            }
        }
    }
}
