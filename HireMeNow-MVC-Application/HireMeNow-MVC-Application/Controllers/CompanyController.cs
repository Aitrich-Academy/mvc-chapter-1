using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow_MVC_Application.Controllers
{
    public class CompanyController : Controller
    {
        //private readonly IPublicService _publicService;
		private readonly ICompanyServices _companyService;
		//public CompanyController(IPublicService publicService)
  //      {
  //          _publicService = publicService;

		//}
        public CompanyController(ICompanyServices companyServices) 
        {
            _companyService= companyServices;
        }
        // GET: CompanyController
      

        // GET: CompanyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public IActionResult MemberRegister()
        {
            return View();
        }


        //seeker registration
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MemberRegister(User user1)
        {
            try
            {
				_companyService.MemberRegister(user1);

                TempData["message"] = "added successfully";

                return RedirectToAction("MemberListing", "Company");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult MemberListing()
        {
            try
            {
              List<User> members=  _companyService.MemberListing();


                return View(members);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        // GET: CompanyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompanyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: CompanyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompanyController/Delete/5
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
