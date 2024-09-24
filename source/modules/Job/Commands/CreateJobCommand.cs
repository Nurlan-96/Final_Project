using FinalProject.Domain.Constants;

namespace Job.Module.Commands
{
    public class CreateJobCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public EducationEnum Education { get; set; }
        public EmploymentTypeEnum EmploymentType { get; set; }
        public ExperienceEnum Experience { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
