using SharedKernel.Domain;

namespace EmailModule.Manager
{
	public interface IEmailManager 
	{
		public Task SendEmail(Email email, CancellationToken cancellationToken);
		public string LoadHTML(string path);
		public string LoadHTML(string path, Dictionary<string, string> replacements);
		public string GetTemplatePath();
	}
}
