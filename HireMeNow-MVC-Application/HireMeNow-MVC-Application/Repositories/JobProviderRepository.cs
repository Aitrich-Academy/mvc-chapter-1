using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Models;

namespace HireMeNow_MVC_Application.Repositories
{
	public class JobProviderRepository:IJobProviderRepository
	{
		private List<Interview> interviews = new List<Interview> { new Interview("Tcs", "developer", "12-02-2023", "Thrissur", "12pm") };

        public bool SheduleInterview(Interview interview)
        {
            var Id = interviews.Count + 1;
            interview.Id = Id;
            interviews.Add(interview);
            return true;
        }

        
	}
}
