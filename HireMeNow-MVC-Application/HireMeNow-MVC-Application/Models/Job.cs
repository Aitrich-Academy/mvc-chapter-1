using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeNow_MVC_Application.Models
{
	public class Job
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Location { get; set; }
		public string Experience { get; set; }
		public string TypeOfWork { get; set; }
		public string Salary { get; set; }
		public string Responsibilities { get; set; }
		public string? Type { get; set; }
		public string? CompanyName { get; set; }
		public Guid CompanyId { get; set; }
		public int Capacity { get; set; }
		public int Applied { get; set; }
		[JsonIgnore]
		public Company? Company { get; set; }

		public Job(string title, string description, string location, string type, string salary, Guid companyId, string company)
		{
			Id = Guid.NewGuid();
			Title = title;
			Description = description;
			Location = location;
			Salary = salary;
			Type = type;
			CompanyName = company;
			CompanyId=companyId;
		}

		public Job()
		{
		}
	}
}
