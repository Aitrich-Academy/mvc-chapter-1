using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Models;

namespace HireMeNow_MVC_Application.Services
{
	public class UserService : IUserService
	{
		public IUserRepository userRepository;
		public IJobRepository jobRepository;
		public UserService(IUserRepository _userRepository, IJobRepository _jobRepository)
		{
			userRepository = _userRepository;
			jobRepository=_jobRepository;
		}
		public bool ApplyJob(Guid jobid, Guid userId)
		{
			return userRepository.ApplyJob(jobid, userId);
			
		}

		public List<Job> GetAppliedJobs(Guid userId)
		{
			List<Guid>AppliedJobsIds= userRepository.getAppliedJobs(userId);
			return jobRepository.GetJobsByIds(AppliedJobsIds);
		}

		public User GetById(Guid id)
		{
			return userRepository.getById(id);
		}

        User IUserService.updateUserProfile(User updatedUser)
        {
            return userRepository.updateUserProfile(updatedUser);
        }
    }
}
