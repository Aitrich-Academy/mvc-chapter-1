using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Models;

namespace HireMeNow_MVC_Application.Repositories
{
    public class JobRepository : IJobRepository
    {
        private List<Job> jobs = new List<Job> { new Job("Dotnet Developer","Senior dotnet developer .","kochi","Fulltime","100000-300000",new Guid(),"Aitrich"),
		new Job("Java Developer","Senior dotnet developer .","kochi","Fulltime","100000-300000",new Guid(),"Aitrich"),
		new Job("Angular Developer","Senior dotnet developer .","kochi","Fulltime","100000-300000",new Guid(),"Aitrich"),
		new Job("Dotnet Developer","Senior dotnet developer .","kochi","Fulltime","100000-300000",new Guid(),"Aitrich"),
		new Job("Dotnet Developer","Senior dotnet developer .","kochi","Fulltime","100000-300000",new Guid(),"Aitrich")};

		public void DeleteById(int id)
		{
			throw new NotImplementedException();
		}

		public void DeleteById(Guid id)
		{
			Job item = jobs.FirstOrDefault(i => i.Id == id);
			if (item != null)
			{
				jobs.Remove(item);
			}
		}

		public Job GetJobById(Guid selectedJobId)
		{
			return jobs.Where(e=>e.Id==selectedJobId).FirstOrDefault();
		}

		public List<Job> GetJobs()
        {
            return jobs;
        }

		public List<Job> GetJobsByIds(List<Guid> appliedJobsIds)
		{
			List<Job> Appliedjobs = new List<Job>();
			appliedJobsIds.ForEach(e=> Appliedjobs.Add(GetJobById(e)));
			return Appliedjobs;


		}

		public void PostJob(Job job)
        {
            job.Id = Guid.NewGuid(); 
            jobs.Add(job);
        }
    }
}
