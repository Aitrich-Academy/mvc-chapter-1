using HireMeNow_MVC_Application.Models;

namespace HireMeNow_MVC_Application.Interfaces
{
	public interface IJobProvider
	{
		List<Interview> sheduledinterviewlist();
		public bool SheduleInterview(Interview interview);
	}
}
