using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeNow_MVC_Application.Models
{
    public class Interview
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string Company { get; set; }
        public string Post { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string Time { get; set; }

        public Interview(string company, string post, string date, string location, string time)
        {
            //  JobId = jobId;
            Company = company;
            Post = post;
            Date = date;
            Location = location;
            Time = time;
        }
        public Interview()
        {
            
        }
    }
}
