using Microsoft.AspNetCore.Http;

namespace Company.Module.Commands
{
    public class CreateCompanyCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
    }
}
