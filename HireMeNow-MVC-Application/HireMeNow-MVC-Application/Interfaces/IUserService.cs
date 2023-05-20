using HireMeNow_MVC_Application.Models;

namespace HireMeNow_MVC_Application.Interfaces
{
	public interface IUserService
	{
		User GetById(Guid id);
		public bool ApplyJob(Guid jobid, Guid userId);
		public List<Job> GetAppliedJobs(Guid userId);
		public User updateUserProfile(User updatedUser);

    }
}
