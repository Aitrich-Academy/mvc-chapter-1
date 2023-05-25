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
        public string? Address { get; set; }
        public Company() { }

        public Company(string name, string email, string website, string phone, string? image, string? about, string? vision, string? mission, string? location,Guid? id=null)
        {
            Name=name;
            Email=email;
            Website=website;
            Phone=phone;
            Image=image;
            About=about;
            Vision=vision;
            Mission=mission;
            Location=location;
            Id=id??Guid.NewGuid();
        }
    }
}
