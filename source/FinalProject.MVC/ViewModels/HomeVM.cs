using FinalProject.Domain.Constants;
using FinalProject.Domain.Entities;
using IdentityModule.Response;

namespace FinalProject.MVC.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<JobPostEntity>? JobPosts { get; set; }
        public UserResponse? User { get; set; }
        public IEnumerable<CategoryEntity>? Categories { get; set; }
        public IEnumerable<CompanyEntity>? Companies { get; set; }
        public IEnumerable<CityEnum>? Cities { get; set; }
    }
}
