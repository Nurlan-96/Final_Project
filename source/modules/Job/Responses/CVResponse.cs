using FinalProject.Domain.Constants;
using FinalProject.Domain.Entities;

namespace Job.Module.Responses
{
    public class CVResponse
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AboutMe { get; set; }
        public string Address { get; set; }
        public int ExpectedSalary { get; set; }
        public int UserId { get; set; }
        public EducationEnum Education { get; set; }
        public CityEnum City { get; set; }
        public ExperienceEnum Experience { get; set; }

        private readonly List<CVJobEntity> _cvjobs;
        public IReadOnlyCollection<CVJobEntity> CVJobPosts => _cvjobs;

        public CVResponse()
        {
            _cvjobs = new List<CVJobEntity>();
        }
    }
}
