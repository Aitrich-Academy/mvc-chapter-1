using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Models;
using HireMeNow_MVC_Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow_MVC_Application.Controllers
{
    public class CompanyController : Controller
    {
        //private readonly IPublicService _publicService;
		private readonly ICompanyServices _companyService;
        IUserService _userService;
     
        public CompanyController(ICompanyServices companyServices, IUserService userService) 
        {
            _companyService= companyServices;
            _userService= userService;
        }
        // GET: CompanyController

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

        public ActionResult Profile()
        {

            var uid = HttpContext.Session.GetString("UserId");
            User user = _userService.GetById(new Guid(uid));
            Company company = new Company();
            if (user.companyId!=null)
            {
                company = _companyService.GetCompanyById(user.companyId.Value);

            }
            return View(company);
        }
        [HttpPost]
        public ActionResult Profile(Company updatedCompany)
        {

            if (updatedCompany.Id!=null)
            {
                updatedCompany = _companyService.Update(updatedCompany);

            }
            return View(updatedCompany);
        }


    }
}
