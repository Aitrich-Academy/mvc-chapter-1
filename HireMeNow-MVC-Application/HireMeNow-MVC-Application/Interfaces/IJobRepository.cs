using HireMeNow_MVC_Application.Models;

namespace HireMeNow_MVC_Application.Interfaces
{
    public interface IJobRepository
    {
        void PostJob(Job job);
        List<Job> GetJobs();
		Job GetJobById(Guid selectedJobId);
		List<Job> GetJobsByIds(List<Guid> appliedJobsIds);
		
		void DeleteById(Guid id);
	}
}
