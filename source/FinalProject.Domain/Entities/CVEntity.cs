using FinalProject.Domain.Constants;
using FinalProject.SharedKernel.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.Entities
{
    public class CVEntity:BaseEntity
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AboutMe { get; set; }
        public string Address { get; set; }
        public int ExpectedSalary { get; set; }
        public EducationEnum Education { get; set; }
        public CityEnum City { get; set; }
        public EmploymentTypeEnum EmploymentType { get; set; }
        public ExperienceEnum Experience { get; set; }
    }
}
