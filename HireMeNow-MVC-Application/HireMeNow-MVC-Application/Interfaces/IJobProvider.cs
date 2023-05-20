using HireMeNow_MVC_Application.Models;

namespace HireMeNow_MVC_Application.Interfaces
{
	public interface IJobProvider
	{
		public bool SheduleInterview(Interview interview);
	}
}
