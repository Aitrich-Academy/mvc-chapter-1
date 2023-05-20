using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeNow_MVC_Application.Models
{
    public class Application
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Job Job { get; set; }
        public string Status { get; set; }
        public Guid CompanyId { get; set; }
        public Application()
        {
            
        }
        public Application(Job job, User user, string status, Guid? CompanyId=null)
        {
            Id=Guid.NewGuid();
			Job = job;
            User = user;
            Status = status;
            CompanyId = CompanyId;
           
        }
    }
}
