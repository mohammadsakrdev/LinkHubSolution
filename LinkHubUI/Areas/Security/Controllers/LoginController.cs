using LinkHubBOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LinkHubUI.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Security/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(tbl_User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Membership.ValidateUser(user.UserEmail, user.Password))
                    {
                        FormsAuthentication.SetAuthCookie(user.UserEmail, false);
                        return RedirectToAction("Index", "Home", new { area = "Common" });
                    }
                    else
                    {
                        TempData["msg"] = "Login Failed";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return View("Index");
                }
            } // end try
            catch(Exception e)
            {
                TempData["msg"] = "Login Failed " + e.Message;
                return RedirectToAction("Index");
            }
        } // end method SignIn

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Common" });
        } // end method SignOut

    }
}