using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OnlineShowCase.Models;

namespace OnlineShowCase.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            var maincategories = Entity.Categories.Where(x => x.SubCategoryId == null);
            return View(maincategories);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {
            try
            {
                if (model.Email.Length < 4 && model.Password.Length < 5)
                {
                    return Redirect("~/Home/Login");
                }
                else
                {
                    var user = Entity.Users.First(x => x.Email == model.Email);
                    if (model.Password == user.Password)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return Redirect("~/Home/");
                    }
                    else
                    {
                        ViewBag.message = "Login failed";
                        return View("Login");
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.message = "Giriş başarısız! " ;
                return View("Login");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            return null;
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Entity.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}