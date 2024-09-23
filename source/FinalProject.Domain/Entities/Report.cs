using FinalProject.SharedKernel.Domain.Seedwork;

namespace FinalProject.Domain.Entities
{
    public class Report : BaseEntity
    {
        public string Reason { get; set; }
        public int JobPostId { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
