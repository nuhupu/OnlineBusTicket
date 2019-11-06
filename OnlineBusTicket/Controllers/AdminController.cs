using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBusTicket.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Route()
        {
            return View();
        }

        public ActionResult EditRoute()
        {
            return View();
        }

        public ActionResult BlockTime()
        {
            return View();
        }

        public ActionResult AddBlockTime()
        {
            return View();
        }

        public ActionResult EditBlockTime()
        {
            return View();
        }

        public ActionResult GroupBlockTime()
        {
            return View();
        }

        public ActionResult AddGroupBlockTime()
        {
            return View();
        }
    }
}