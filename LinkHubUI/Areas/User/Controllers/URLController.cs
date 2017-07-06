using LinkHubBLL;
using LinkHubBOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.User.Controllers
{
    [Authorize(Roles = "A,U")]
    public class URLController : Controller
    {
        private UserAreaBs db;

        public URLController()
        {
            db = new UserAreaBs();
        }

        // GET: User/URL
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList ( db.CategoryBs.GetAll(), "CategoryId", "CategoryName");
            ViewBag.UserId = new SelectList(db.UserBs.GetAll(), "UserId", "UserEmail");
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Url url)
        {
            try
            {
                url.IsApproved = "P";
                url.UserId = db.UserBs.GetAll().Where(x => x.UserEmail == User.Identity.Name).FirstOrDefault().UserId;
                if (ModelState.IsValid)
                {
                    db.UrlBs.Insert(url);
                    TempData["msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(db.CategoryBs.GetAll(), "CategoryId", "CategoryName");
                    ViewBag.UserId = new SelectList(db.UserBs.GetAll(), "UserId", "UserEmail");
                    return View("Index");
                }
            }
            catch
            {
                TempData["msg"] = "Create Failed";

                return RedirectToAction("Index");
            }
        }
    }
}