namespace IdentityModule.Response
{
	public class UserResponse
	{
		public int Id { get; set; }
		public string Fullname { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public RoleResponse Role { get; set; }
	}
}