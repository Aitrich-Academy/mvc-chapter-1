using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Models;

namespace HireMeNow_MVC_Application.Repositories
{
	public class JobProviderRepository:IJobProviderRepository
	{
		private List<Interview> interviews = new List<Interview> { new Interview("Tcs", "developer", "12-02-2023", "Thrissur", "12pm"), new Interview("Wipro", "developer", "10-02-2023", "EKM", "12pm") , new Interview("Zitech", "developer", "10-02-2023", "Thrissur", "10pm") };

        public bool SheduleInterview(Interview interview)
        {
            var Id = interviews.Count + 1;
            interview.Id = Id;
            interviews.Add(interview);
            return true;
        }
		public List<Interview> SheduledInterviewList()
		{
			return interviews.ToList();
		}


	}
}
