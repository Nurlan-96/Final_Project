namespace UserModule.Commands
{
	public class ForgotPasswordCommand
	{
		public string Email { get; set; }	
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
	}
}