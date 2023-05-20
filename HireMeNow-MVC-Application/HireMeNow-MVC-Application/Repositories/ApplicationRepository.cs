using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Models;

namespace HireMeNow_MVC_Application.Repositories
{
	public class ApplicationRepository : IApplicationRepository
	{
		List<Application> _applications=new List<Application>();
		public List<Application> GetAll(Guid userId)
		{
			return _applications.Where(e=>e.User?.Id==userId).ToList();
		}
		public void AddApplication(User user,Job job)
		{
			_applications.Add(new Application(job,user,"Pending"));
		}
	}
}
