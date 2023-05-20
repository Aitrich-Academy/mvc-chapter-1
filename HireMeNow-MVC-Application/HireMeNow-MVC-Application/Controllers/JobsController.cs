using HireMeNow_MVC_Application.Interfaces;
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
    }
}
