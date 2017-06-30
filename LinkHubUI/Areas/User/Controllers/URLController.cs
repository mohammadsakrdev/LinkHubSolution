using LinkHubBLL;
using LinkHubBOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.User.Controllers
{
    public class URLController : Controller
    {
        private UrlBs urlbs;
        private CategoryBs catbs;
        private UserBs userbs;

        public URLController()
        {
            urlbs = new UrlBs();
            catbs = new CategoryBs();
            userbs = new UserBs();
        }

        // GET: User/URL
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList ( catbs.GetAll(), "CategoryId", "CategoryName");
            ViewBag.UserId = new SelectList(userbs.GetAll(), "UserId", "UserEmail");
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Url url)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    urlbs.Insert(url);
                    TempData["msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(catbs.GetAll(), "CategoryId", "CategoryName");
                    ViewBag.UserId = new SelectList(userbs.GetAll(), "UserId", "UserEmail");
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