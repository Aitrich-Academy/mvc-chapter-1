using HireMeNow_MVC_Application.Models;

namespace HireMeNow_MVC_Application.Interfaces
{
	public interface IJobProviderRepository
	{
		bool SheduleInterview(Interview interview);
	}
}
