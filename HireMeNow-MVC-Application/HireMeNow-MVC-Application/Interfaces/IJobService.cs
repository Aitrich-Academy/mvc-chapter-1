using HireMeNow_MVC_Application.Models;

namespace HireMeNow_MVC_Application.Interfaces
{
    public interface IJobService
    {
        public void PostJob(Job job);
        public List<Job> GetJobs();
        public Job getJobById(Guid selectedJobId);
		void DeleteItemById(Guid id);
	}
}
