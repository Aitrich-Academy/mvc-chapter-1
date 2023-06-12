using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow_MVC_Application.Controllers
{
    public class PublicController : Controller
    {
        private readonly IPublicService _publicService;
        public PublicController(IPublicService publicService)
        {
            _publicService= publicService;
        }
 


        public IActionResult Registration()
        {
            return View();
		}


        //seeker registration
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(User user)
        {
            try
            {
                _publicService.Register(user);

                TempData["message"] = "added successfully";

                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        // POST: PublicController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email,string password)
        {
            try

            {
               var result= _publicService.LoginJobSeeker(email,password);
                if (result != null)
                {
                    TempData["msg"] = "logged successfully";
                    HttpContext.Session.SetString("UserId", result.Id.ToString());
                    ViewData["Role"]=result.Role.ToString();
                    ViewBag.UserEmail=result.Email;

					return RedirectToAction("Index","User");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
              
            }
            catch
            {
                return View();
            }
        }








       
     
        public IActionResult Index()
        {
            return View();
        }


    }
}
