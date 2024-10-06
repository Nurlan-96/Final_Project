namespace UserModule.Commands
{
	public class ResetPasswordCommand
	{
		public Guid Id { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
	}
}