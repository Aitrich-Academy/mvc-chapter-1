using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HireMeNow_MVC_Application.Models
{
	public class Profile
	{
		public string? About { get; set; } = "this is a sample about me ";
		public List<string>? Skills { get; set; } = new List<string>();
		public List<Education>? Educations { get; set; } = new List<Education>();
		public List<Experience>? Experiences { get; set; } = new List<Experience>();
		public List<Guid>? AppliedJobs { get; set; } = new List<Guid>();

		public string? Designation { get; set; }
		public string? UserId { get; set; }
		public Guid? companyId { get; set; }

		public string? Image { get; set; }

		public IFormFile? FormFile { get; set; }

		public string? Skill { get; set; }
		public Education? Education { get; set; } = new Education();
		public Experience? Experience { get; set; } = new Experience();

	}
}
