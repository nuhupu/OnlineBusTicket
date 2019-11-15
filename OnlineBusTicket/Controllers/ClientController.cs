using OnlineBusTicket.Models;
using OnlineBusTicket.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBusTicket.Controllers
{
    public class ClientController : Controller
    {
        private SRCTravelAgenciesEntities db = new SRCTravelAgenciesEntities();
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Route()
        {
            ViewBag.CounterName = new SelectList(db.Counters, "counId", "counName");
            var dao = new AdminController();
            var routeViews = dao.ListRoute();
            return View(routeViews);
        }

        public IEnumerable<RouteView> ListRoute()
        {
            List<RouteView> routeViews = new List<RouteView>();
            var result = (from a in db.Routes
                          join b in db.BlockTimes on a.btId equals b.btId
                          join c in db.Buses on a.bId equals c.bId
                          //join d in db.BusSchedules on a.btId equals d.btId
                          select new
                          {
                              a,
                              b,
                              c,
                              //d
                          });

            RouteView routeView;
            foreach (var tem in result)
            {
                routeView = new RouteView();
                routeView.route = tem.a;
                routeView.block = tem.b;
                routeView.bus = tem.c;
                routeViews.Add(routeView);
            }

            return routeViews;

        }
    }
}