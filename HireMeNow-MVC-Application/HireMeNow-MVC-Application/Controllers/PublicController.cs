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
                    //HttpContext.Session.SetInt32("UserId",result.Id);
                    return View("Registration");
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








        // GET: PublicController/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: PublicController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User collection)
        {
            try
            {
                _publicService.Register(collection);
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PublicController/Edit/5


        // GET: PublicController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PublicController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
