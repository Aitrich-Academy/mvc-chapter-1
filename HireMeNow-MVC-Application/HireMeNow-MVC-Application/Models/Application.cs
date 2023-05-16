using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeNow_MVC_Application.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string Experience { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Qualification { get; set; }

        public Application(int jobId, string applicantName, string location, string qualification,string experience)
        {
            Id = jobId;
            Name = applicantName;
            Location = location;
            Qualification = qualification;
            Experience = experience;
        }
    }
}
