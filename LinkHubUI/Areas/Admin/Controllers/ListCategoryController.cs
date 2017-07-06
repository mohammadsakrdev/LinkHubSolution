using LinkHubBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ListCategoryController : Controller
    {
        private AdminBs db;

        public ListCategoryController()
        {
            db = new AdminBs();
        }
        // GET: Admin/ListCategory
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.OrderBy = SortBy;
            var cat = db.CategoryBs.GetAll();

            switch (SortBy)
            {
                case "CategoryName":
                    switch (SortOrder)
                    {
                        case "Asc":
                            cat = cat.OrderBy(x => x.CategoryName).ToList();
                            break;
                        case "Desc":
                            cat = cat.OrderByDescending(x => x.CategoryName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "CategoryDesc":
                    switch (SortOrder)
                    {
                        case "Asc":
                            cat = cat.OrderBy(x => x.CategoryDesc).ToList();
                            break;
                        case "Desc":
                            cat = cat.OrderByDescending(x => x.CategoryDesc).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            } // end switch
            ViewBag.TotalPages = Math.Ceiling(db.CategoryBs.GetAll().Count() / 10.0);

            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            cat = cat.Skip((page - 1) * 10).Take(10).ToList();

            return View(cat);
        } // end method Index

        public ActionResult Delete(int id)
        {
            try
            {
                db.CategoryBs.Delete(id);
                TempData["msg"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["msg"] = "Delete Failed";

                return RedirectToAction("Index");
            }
        } // end method Delete

    }
}