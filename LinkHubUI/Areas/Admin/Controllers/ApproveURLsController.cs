using LinkHubBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ApproveURLsController : Controller
    {
        private AdminBs db;

        public ApproveURLsController()
        {
            db = new AdminBs();
        }

        // GET: Admin/ApproveURLs
        public ActionResult Index(string Status)
        {
            ViewBag.Status = (Status == null ? "P" : Status);
            if (Status == null)
            {
                var urls = db.UrlBs.GetAll().Where(x => x.IsApproved == "P").ToList();
                return View(urls);
            }
            else
            {
                var urls = db.UrlBs.GetAll().Where(x => x.IsApproved == Status).ToList();
                return View(urls);
            }
        } // end method Index

        public ActionResult Approve(int id)
        {
            try
            {
                var url = db.UrlBs.GetByID(id);
                url.IsApproved = "A";
                db.UrlBs.Update(url);
                TempData["msg"] = "Approved "  + url.IsApproved + url.UrlTitle;
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                TempData["msg"] = "Approval failed " + e.Message ;
                return RedirectToAction("Index");
            }
        } // end method Approve

        public ActionResult Reject(int id)
        {
            try
            {

                var url = db.UrlBs.GetByID(id);
                url.IsApproved = "R";
                db.UrlBs.Update(url);
                TempData["msg"] = "Rejected";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["msg"] = "Rejection Failed";
                return RedirectToAction("Index");
            }
        } // end method Reject
    }
}