using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeNow_MVC_Application.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Salary { get; set; }
        public string? Type { get; set; }
        public string? Company { get; set; }
        public int Capacity { get; set; }
        public int Applied { get; set; }

        public Job(string title, string description, string location, string type, string salary, string company)
        {
            //Id = id;
            Title = title;
            Description = description;
            Location = location;
            Salary = salary;
            Type = type;
            Company = company;
        }

        public Job()
        {
        }
    }
}
