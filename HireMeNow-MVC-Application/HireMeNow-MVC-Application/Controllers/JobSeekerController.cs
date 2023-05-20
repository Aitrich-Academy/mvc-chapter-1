using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Models;
using HireMeNow_MVC_Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow_MVC_Application.Controllers
{
    public class JobSeekerController : Controller
    {
        IJobService _jobService;
        IUserService _userService;
		IUserRepository _userRepository;
		IApplicationService _applicationService;
		public JobSeekerController(IJobService jobService, IUserService userService,IUserRepository userRepository,IApplicationService applicationService)
        {
            _jobService=jobService;
            _userService=userService;
			_userRepository=userRepository;
			_applicationService=applicationService;
        }
        public IActionResult AllJobs(Guid? selectedJobId =null)
		{
			var result = _userRepository.getuser();
			HttpContext.Session.SetString("UserId", result.Id.ToString());
			List<Job> jobs = _jobService.GetJobs();

			Job selectedJob=new Job();
			selectedJob=jobs.FirstOrDefault(new Job());
			if (selectedJobId !=null)
            {
                selectedJob=_jobService.getJobById(selectedJobId.Value);

			}
            
            ViewBag.selectedJob =selectedJob;
			return View(jobs);
        }
        [HttpPost]
		public IActionResult ApplyJob(string jobId = null)
        {
            if (jobId!=null)
            {
				var uid = HttpContext.Session.GetString("UserId");
				//    Job job = _jobService.getJobById(new Guid(jobId));
				//bool res=_userService.ApplyJob(new Guid(jobId),new Guid(uid));
				_applicationService.AddApplication(new Guid(jobId), new Guid(uid));

				//if (res)
    //            {
                    return RedirectToAction("MyApplications");
                //}

			}
			return RedirectToAction("AllJobs");
		}

		public IActionResult MyApplications(Guid? selectedJobId = null)
		{
			var uid = HttpContext.Session.GetString("UserId");
			//List<Job> jobs = _userService.GetAppliedJobs(new Guid(uid));
			List<Application> jobs=_applicationService.GetAll(new Guid(uid));

			Job selectedJob = new Job();
			selectedJob=jobs.FirstOrDefault()?.Job;
			if (selectedJobId !=null)
			{
				selectedJob=_jobService.getJobById(selectedJobId.Value);

			}

			ViewBag.selectedJob =selectedJob;
			return View(jobs);
		}

		public IActionResult Profile()
		{
			var uid = HttpContext.Session.GetString("UserId");
			User user = _userService.GetById(new Guid(uid));
			return View(user);
		}
		[HttpPost]
        public IActionResult Profile(User updateUser)
		{
            var uid = HttpContext.Session.GetString("UserId");
            User user = _userService.GetById(new Guid(uid));
            user.About= updateUser.About??user.About;
            //user.Skill= updateUser.About??user.About;
            //user.About= updateUser.About??user.About;

            if (updateUser.Skill !=null){
				user.Skills.Add(updateUser.Skill);
                updateUser.Skill=null;
            }
            if (updateUser.Education.Course !=null)
            {
                user.Educations.Add(updateUser.Education);
                updateUser.Education=null;
            }
            if (updateUser.Experience.JobTitle !=null)
            {
                user.Experiences.Add(updateUser.Experience);
                updateUser.Experience=null;
            }
            ModelState.Clear();
            user=_userService.updateUserProfile(user);

            return View(user);
		}




    }
}
