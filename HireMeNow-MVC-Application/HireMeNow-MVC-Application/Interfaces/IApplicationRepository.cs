using HireMeNow_MVC_Application.Models;

namespace HireMeNow_MVC_Application.Interfaces
{
	public interface IApplicationRepository
	{
		public List<Application> GetAll(Guid userId);
		public void AddApplication(User user, Job job);
	}
}
