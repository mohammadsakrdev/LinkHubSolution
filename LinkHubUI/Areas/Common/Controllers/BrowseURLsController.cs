using LinkHubBOL;
using LinkHubBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    public class BrowseURLsController : Controller
    {
        private UrlBs db;
        public BrowseURLsController()
        {
            db = new UrlBs();
        }
        // GET: Common/BrowseURLs
        public ActionResult Index()
        {
            var urls = db.GetAll().Where(u => u.IsApproved == "A").ToList();
            return View(urls);
        }
    }
}