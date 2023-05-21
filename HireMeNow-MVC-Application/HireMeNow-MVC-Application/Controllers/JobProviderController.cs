using HireMeNow_MVC_Application.DTO;
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
		private readonly IJobService _jobService;
	
		public JobProviderController(IJobProvider jobProvider,IJobService jobService)
		{
			_jobProvider = jobProvider;
			_jobService=jobService;
		}
		public IActionResult InterviewShedule()
		{

			return View();
		}
		[HttpPost]
		public ActionResult InterviewShedule(Interview interviews)
		{
			var rslt = _jobProvider.SheduleInterview(interviews);
			if (rslt == true)
			{
				TempData["msg"] = "Interview is sheduled";

			}

			return View();

		}
		
		public IActionResult SheduledInterviewList()
		{
			List<Interview> sheduledinterviewlist = _jobProvider.sheduledinterviewlist();
			return View(sheduledinterviewlist);
		}
		public IActionResult Dashboard()
		{
			TempData["listedJobs"] = _jobService.GetJobs().Count;
			TempData["interviewSheduled"] = _jobProvider.sheduledinterviewlist().Count;
			
			return View();
		}
	}






















}
