using LinkHubBLL;
using LinkHubBOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryBs db;

        public CategoryController()
        {
            db = new CategoryBs();
        }
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Category category)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    db.Insert(category);
                    TempData["msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
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