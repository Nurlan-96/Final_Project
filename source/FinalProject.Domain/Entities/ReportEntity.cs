using FinalProject.SharedKernel.Domain.Seedwork;

namespace FinalProject.Domain.Entities
{
    public class ReportEntity : BaseEntity
    {
        public string Reason { get; set; }
        public int JobPostId { get; set; }
        public JobPostEntity JobPostEntity { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public bool IsDeleted { get; set; }
    }
}
