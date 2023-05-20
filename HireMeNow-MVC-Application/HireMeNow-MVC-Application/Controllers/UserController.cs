using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow_MVC_Application.Controllers
{
    public class UserController : Controller
    {
        IJobService _jobService;
        IUserService _userService;
        IUserRepository _userRepository;
        IApplicationService _applicationService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserController(IJobService jobService, IUserService userService, IUserRepository userRepository, IApplicationService applicationService, IWebHostEnvironment webHostEnvironment)
        {
            _jobService=jobService;
            _userService=userService;
            _userRepository=userRepository;
            _applicationService=applicationService;
            _webHostEnvironment=webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> _DetailView()
        {
            var uid = HttpContext.Session.GetString("UserId");
            User user = _userService.GetById(new Guid(uid));
            return PartialView("_DetailView", user);
        }
        //Education View   
        public async Task<ActionResult> _EducationView()
        {
            var uid = HttpContext.Session.GetString("UserId");
            User user = _userService.GetById(new Guid(uid));
            return PartialView("_EducationView", user.Educations);
        }
        public async Task<ActionResult> _AddEducationView()
        {
          
            return PartialView("_AddEducationView");
        }
        [HttpPost]
        public async Task<JsonResult> _AddEducationView([FromBody]  Education education)
        {
            string Result = "";
            var uid = HttpContext.Session.GetString("UserId");
            User user = _userService.GetById(new Guid(uid));
            user.Educations.Add(education);
            _userService.updateUserProfile(user);
            Result = "Success";
            return Json(Result);
        }

        //Skills View 
        public async Task<ActionResult> SkillsView()
        {
            var uid = HttpContext.Session.GetString("UserId");
            User user = _userService.GetById(new Guid(uid));
            return PartialView("SkillsView", user.Skills);
        }
        public async Task<ActionResult> AddSkillsView()
        {

            return PartialView("AddSkillsView");
        }
        [HttpPost]
        public async Task<JsonResult> AddSkill(string skill)
        {
            string Result = "";
            if (skill!=null)
            {
                var uid = HttpContext.Session.GetString("UserId");
                User user = _userService.GetById(new Guid(uid));
                user.Skills.Add(skill);
                _userService.updateUserProfile(user);
                Result = "Success";
            }
           
            return Json(Result);
        }



        //Experience View   

        public async Task<ActionResult> _ExperienceView()
        {
            var uid = HttpContext.Session.GetString("UserId");
            User user = _userService.GetById(new Guid(uid));
            return PartialView("_ExperienceView", user.Experiences);
        }
        public async Task<ActionResult> _AddExperienceView()
        {
          
            return PartialView("_AddExperienceView");
        }
        [HttpPost]
        public async Task<JsonResult> _AddExperienceView([FromBody]  Experience experience)
        {
            string Result = "";
            var uid = HttpContext.Session.GetString("UserId");
            User user = _userService.GetById(new Guid(uid));
            user.Experiences.Add(experience);
            _userService.updateUserProfile(user);
            Result = "Success";
            return Json(Result);
        }


        //About 


        //public async Task<ActionResult> _AboutView()
        //{
        //    var uid = HttpContext.Session.GetString("UserId");
        //    User user = _userService.GetById(new Guid(uid));
        //    return PartialView("_AboutView", user.Experiences);
        //}
        public async Task<ActionResult> EditDetailsView()
        {
            var uid = HttpContext.Session.GetString("UserId");
            User user = _userService.GetById(new Guid(uid));
            return PartialView("EditDetailsView", user);
        }
        [HttpPost]
        public async Task<JsonResult> UpdateDetails([FromBody] User updateduser)
        {
            string Result = "";
            var uid = HttpContext.Session.GetString("UserId");
            User user = _userService.GetById(new Guid(uid));
            user.FirstName= updateduser.FirstName??user.FirstName;
            user.LastName= updateduser.LastName??user.LastName;
            user.Gender= updateduser.Gender??user.Gender;
            user.Location= updateduser.Location??user.Location;
            user.Designation= updateduser.Designation??user.Designation;
            user.Phone= updateduser.Phone!=null? updateduser.Phone:user.Phone;
            user.About= updateduser.About??user.About;
            _userService.updateUserProfile(user);
            Result = "Success";
            return Json(Result);
        }

        [HttpPost]
        public async Task<JsonResult> UploadFileAsync(IFormFile fileData)
        {
            if (fileData != null)
            {
                try
                {
                    IFormFile myFile = fileData;
                    if (myFile != null)
                    {
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");

                        if (!Directory.Exists(uploadsFolder))
                        {
                            // Create the "Uploads" folder if it doesn't exist
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(myFile.FileName);
                        string filePath = Path.Combine(uploadsFolder, fileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await myFile.CopyToAsync(fileStream);
                        }

                        var uid = HttpContext.Session.GetString("UserId");
                        User user = _userService.GetById(new Guid(uid));
                        user.Image=fileName;
                        _userService.updateUserProfile(user);

                        //string savepath = Server.MapPath("~/Images");
                        //String savethumbImagePath = savepath + @"\" + myFile.FileName;
                        //myFile.SaveAs(savethumbImagePath);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return Json("Success");
        }

    }
}
