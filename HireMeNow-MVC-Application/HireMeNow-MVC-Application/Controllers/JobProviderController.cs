using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Managers;
using HireMeNow_MVC_Application.Models;
using HireMeNow_MVC_Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow_MVC_Application.Controllers
{
	public class JobProviderController : Controller
	{
        private readonly IJobProvider _jobProvider;
        public JobProviderController(IJobProvider jobProvider)
		{
            _jobProvider = jobProvider;
		}
		public IActionResult InterviewShedule()
		{

			return View();
		}
		[HttpPost]
		public ActionResult InterviewShedule(Interview interviews)
		{
			var rslt = _jobProvider.SheduleInterview(interviews);
			if(rslt==true)
			{
				TempData["msg"] = "Interview is sheduled";
              
            }

			return View();

		}
	}






















}
