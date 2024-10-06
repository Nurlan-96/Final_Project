using Company.Module.Responses;
using FinalProject.Domain.Constants;

namespace Job.Module.Responses
{
    public class JobPostResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public CompanyResponse Company { get; set; }
        public CategoryResponse Category { get; set; }
        public CityEnum City { get; set; }
        public EducationEnum Education { get; set; }
        public EmploymentTypeEnum EmploymentType { get; set; }
        public ExperienceEnum Experience { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
