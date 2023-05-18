using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Managers;
using HireMeNow_MVC_Application.Models;
using HireMeNow_MVC_Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow_MVC_Application.Controllers
{
    public class AdminController : Controller
    {
       
        private readonly IAdminService _adminService;
        string uid;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public User loggedUser;
        public IActionResult Edit()
        {
            User user = _adminService.getLoggedUser();
            if (user.Email != null)
            {
                uid = HttpContext.Session.GetString("UserId");
                if (uid != null)
                {
                    loggedUser = _adminService.GetUserById(new Guid(uid));
                    return View(loggedUser);
                }
                else
                {
                    return RedirectToPage("Edit");
                }
                return View();
            }
            //User adminToUpdate = adminList.FirstOrDefault(a => a.Email == Email);

            return View(loggedUser);
        }
        [HttpPost]
        public IActionResult Edit(User updatedAdmin)
        {

            uid = HttpContext.Session.GetString("UserId");
          if (uid != null)
            {
                _adminService.UpdateProfile(updatedAdmin);
                TempData["messag"] = "Updated successfully";
            }
            return View();
        }
    }
}
