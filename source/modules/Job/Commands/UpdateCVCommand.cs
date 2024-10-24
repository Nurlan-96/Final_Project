using FinalProject.Domain.Constants;

namespace Job.Module.Commands
{
    public class UpdateCVCommand
    {
        public int CVId { get; set; }
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
        public List<UpdateCVJobCommand> Jobs { get; set; } = new List<UpdateCVJobCommand>();

    }
}
