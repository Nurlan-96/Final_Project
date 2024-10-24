using FinalProject.Domain.Constants;
using FinalProject.SharedKernel.Domain.Seedwork;

namespace FinalProject.Domain.Entities
{
    public class CVJobEntity : BaseEntity
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public CityEnum City { get; set; }
        public int? CVEntityId { get; set; }
        public CVEntity CVEntity { get; set; }
    }
}
