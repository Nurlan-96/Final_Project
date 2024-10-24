using FinalProject.Domain.Constants;

namespace Job.Module.Commands
{
    public class CreateCVJobCommand
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public CityEnum City { get; set; }
        public int CVEntityId { get; set; }
    }
}
