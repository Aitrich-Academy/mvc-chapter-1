namespace HireMeNow_MVC_Application.Models
{
    public class Profile
    {
        public string? About { get; set; } = "this is a sample about me ";
        public List<string>? Skills { get; set; }=new List<string>();
        public List<Education>? Education { get; set; }=new List<Education>();
        public List<Experience>? Experiences { get; set; } = new List<Experience>();
        public List<int>? AppliedJobs { get; set; } = new List<int>();

        public string? Designation { get; set; }
        public string? UserId { get; set; }
        public int companyId { get; set;}

    }
}
