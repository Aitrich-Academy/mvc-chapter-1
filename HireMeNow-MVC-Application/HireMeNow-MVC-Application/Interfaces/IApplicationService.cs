
using HireMeNow_MVC_Application.Models;

namespace HireMeNow_MVC_Application.Interfaces
{
	public interface IApplicationService
	{
		public List<Application> GetAll(Guid userId);
		public void AddApplication(Guid userId, Guid jobId);
	}
}
