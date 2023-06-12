using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow_MVC_Application.Controllers
{
    public class JobsController : Controller
    {
        IJobService _jobService;
        public JobsController(IJobService jobService)
        {
            _jobService=jobService;
        }
        public IActionResult Index()
        {
            return View(_jobService.GetJobs());
        }

		public IActionResult PostJob()
		{
			return View();
		}

		[HttpPost]
		public IActionResult PostJob(Job job)
		{
			_jobService.PostJob(job);
			TempData["message"] = "Posted successfully";
			return RedirectToAction("Joblists");
		}
		public IActionResult Joblists()
		{
			return View(_jobService.GetJobs());
		}
		[HttpPost]
		public IActionResult Remove(Guid id)
		{
			//_jobService.GetJobs();
			_jobService.DeleteItemById(id);

			return RedirectToAction("JobLists");
	}

	}
}
