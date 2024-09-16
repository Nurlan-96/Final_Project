namespace FinalProject.SharedKernel.Domain.Seedwork
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        protected BaseEntity()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
