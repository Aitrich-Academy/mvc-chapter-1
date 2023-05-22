using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Models;

namespace HireMeNow_MVC_Application.Services
{
    public class JobService : IJobService
    {
        IJobRepository _jobRepository;
        public JobService(IJobRepository jobRepository )
        {
            _jobRepository=jobRepository;
        }

	
			
		public void DeleteItemById(Guid id)
		{
			_jobRepository.DeleteById(id);

		}

		public Job getJobById(Guid selectedJobId)
		{
			return _jobRepository.GetJobById(selectedJobId);
		}

		public List<Job> GetJobs()
        {
           return _jobRepository.GetJobs();
        }

        public void PostJob(Job job)
        {
            _jobRepository.PostJob(job);
        }
    }
}
