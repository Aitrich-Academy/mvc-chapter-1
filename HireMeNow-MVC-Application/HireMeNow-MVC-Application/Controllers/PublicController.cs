using HireMeNow_MVC_Application.Interfaces;
using HireMeNow_MVC_Application.Models;
using Microsoft.AspNetCore.Http;
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
        // GET: PublicController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PublicController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PublicController/Edit/5
        public ActionResult Login()
        {
            return View();
        }

        // POST: PublicController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(IFormCollection collection)
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
