using FinalProject.SharedKernel.Domain.Seedwork;

namespace FinalProject.Domain.Entities
{
    public class CompanyEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address {  get; set; }
        public bool IsDeleted { get; set; }

    }
}
