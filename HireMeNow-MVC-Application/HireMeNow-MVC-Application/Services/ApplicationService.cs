using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Models;
using HireMeNow_MVC_Application.Repositories;

namespace HireMeNow_MVC_Application.Services
{
	public class ApplicationService : IApplicationService
	{
		public IUserRepository _userRepository;
		IApplicationRepository _applicationRepository;
		public IJobRepository _jobRepository;
		public ApplicationService(IUserRepository userRepository,IApplicationRepository applicationRepository, IJobRepository jobRepository)
        {
			_applicationRepository = applicationRepository;
			_userRepository=userRepository;
			_jobRepository=jobRepository;
        }

		public void AddApplication(Guid jobId, Guid userId)
		{
			User user=_userRepository.getById(userId);
			Job job= _jobRepository.GetJobById(jobId);
			_applicationRepository.AddApplication(user, job);
			
		}

		public List<Application> GetAll(Guid userId)
		{
			return _applicationRepository.GetAll(userId);
		}
	}
}
