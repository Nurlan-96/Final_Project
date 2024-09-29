namespace SharedKernel.Domain
{
	/// <summary>
	/// Email Template
	/// </summary>
	public class Email
	{
		public string To { get; set; }
		public string From { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
		public bool IsHtml { get; set; } = false;
	}
}
