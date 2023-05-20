namespace HireMeNow_MVC_Application.Models
{
	public class Company
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Website { get; set; }
		public string Phone { get; set; }
		public string? Image { get; set; }
		public string? About { get; set; }
		public string? Vision { get; set; }
		public string? Mission { get; set; }
		public string? Location { get; set; }
		public Company() { }
	}
}
