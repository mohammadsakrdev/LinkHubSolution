using LinkHubBLL;
using LinkHubBOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class QuickURLSubmitController : Controller
    {
        private UserAreaBs db;

        public QuickURLSubmitController()
        {
            db = new UserAreaBs();
        }
        // GET: Common/QuickURLSubmit
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(db.CategoryBs.GetAll(), "CategoryId", "CategoryName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(QuickURLSubmitModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(db.CategoryBs.GetAll(), "CategoryId", "CategoryName");

                    return View();
                }
            }
            catch(Exception e)
            {
                return RedirectToAction("Index");
            }
        }// end create
    }
}