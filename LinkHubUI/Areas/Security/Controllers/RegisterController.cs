using LinkHubBLL;
using LinkHubBOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private SecurityBs db;
        public RegisterController()
        {
            db = new SecurityBs();
        }
        // GET: Security/Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_User user)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    user.Role = "U";
                    db.UserBs.Insert(user);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
            }
            catch(Exception e)
            {
                return View("Index");
            }
        } // end method Create


    }
}