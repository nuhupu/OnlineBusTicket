using OnlineBusTicket.Models;
using OnlineBusTicket.Models.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBusTicket.Controllers
{
    public class AdminController : Controller
    {
        private SRCTravelAgenciesEntities db = new SRCTravelAgenciesEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        #region BlockTime
        public ActionResult BlockTime()
        {
            ViewBag.CounterName = new SelectList(db.Counters, "counId", "counName");
            var blockTimeList = from a in db.BlockTimes
                                select a;
            return View(blockTimeList);
        }



        public ActionResult AddBlockTime()
        {
            ViewBag.CounterId = new SelectList(db.Counters, "counId", "counName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBlockTime(BlockTime blockTime)
        {
            ViewBag.CounterId = from a in db.Counters
                                select a;
            try
            {
                if (ModelState.IsValid)
                {

                    var isExist = db.BlockTimes.FirstOrDefault(a => a.StartTime.Equals(blockTime.StartTime) && a.StartPlace.Equals(blockTime.StartPlace) && a.Destination.Equals(blockTime.Destination));
                    if (isExist == null)
                    {
                        db.BlockTimes.Add(blockTime);
                        db.SaveChanges();
                        return RedirectToAction("BlockTime", "Admin");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Block time is existed");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(blockTime);
        }

        public ActionResult EditBlockTime()
        {
            return View();
        }
        #endregion BlockTime

        #region BusSchedule
        public ActionResult BusSchedule()
        {
            ViewBag.CounterName = new SelectList(db.Counters, "counId", "counName");
            var dao = new AdminController();
            var busScheduleList = dao.ListBusSchedule();
            return View(busScheduleList);

        }

        public IEnumerable<BusScheduleView> ListBusSchedule()
        {
            List<BusScheduleView> busScheduleViews = new List<BusScheduleView>();
            var result = (from a in db.BusSchedules
                          join b in db.BlockTimes on a.btId equals b.btId
                          join c in db.Buses on a.bId equals c.bId
                          select new
                          {
                              a,
                              b,
                              c,
                          });

            BusScheduleView busTimeView;
            foreach (var tem in result)
            {
                busTimeView = new BusScheduleView();
                busTimeView.busSchedule = tem.a;
                busTimeView.block = tem.b;
                busTimeView.bus = tem.c;
                busScheduleViews.Add(busTimeView);
            }

            return busScheduleViews;

        }



        private IEnumerable<Bus> GetAllBuses()
        {
            var allBus = from a in db.Buses select a;
            return allBus;
        }

        private IEnumerable<BlockTime> GetAllBlockTimes()
        {
            var allBlockTimes = from a in db.BlockTimes select a;
            return allBlockTimes;
        }

        private IEnumerable<SelectListItem> GetSelectListBuses(IEnumerable<Bus> buses)
        {
            var selectList = new List<SelectListItem>();
            foreach (var item in buses)
            {
                selectList.Add(new SelectListItem
                {
                    Value = item.bId.ToString(),
                    Text = item.bNumber
                });
            }
            return selectList;
        }

        private IEnumerable<SelectListItem> GetSelectListBlockTimes(IEnumerable<BlockTime> blockTimes)
        {
            var selectList = new List<SelectListItem>();
            foreach (var item in blockTimes)
            {
                selectList.Add(new SelectListItem
                {
                    Value = item.btId.ToString(),
                    Text = item.btId.ToString()
                });
            }
            return selectList;
        }

        public ActionResult AddBusSchedule()
        {
            ViewBag.Bus = new SelectList(db.Buses, "bId", "bNumber");
            ViewBag.BlockTime = new SelectList(db.BlockTimes, "btId", "btId");
            ViewBag.BusSchedule = new SelectList(db.BusSchedules, "btId", "btId");
            var admin = new AdminController();
            var buses = GetAllBuses();
            var blockTimes = GetAllBlockTimes();
            admin.GetSelectListBuses(buses);
            admin.GetSelectListBlockTimes(blockTimes);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBusSchedule(BusSchedule busSchedule)
        {



            var admin = new AdminController();
            var buses = GetAllBuses();
            var blockTimes = GetAllBlockTimes();


            ViewBag.Bus = admin.GetSelectListBuses(buses); ;
            ViewBag.BlockTime = admin.GetSelectListBlockTimes(blockTimes); ;
            try
            {
                if (ModelState.IsValid)
                {

                    var isExist = db.BusSchedules.FirstOrDefault(a => a.bId.Equals(busSchedule.bId) && a.btId.Equals(busSchedule.btId));
                    try
                    {
                        if (isExist == null)
                        {
                            db.BusSchedules.Add(busSchedule);
                            db.SaveChanges();
                            ModelState.AddModelError("", "Bus schedule is added");
                        }
                        else
                        {
                            ModelState.AddModelError("", "This schedule is existed");
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }


                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(busSchedule);
        }

        #endregion BusSchedule

        #region Route
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRoute(int b, int bt, double p, DateTime d)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    db.Routes.Add(new Route {bId = b,btId = bt, rPrice = p,date = d });
                    db.SaveChanges();
                    

                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        public ActionResult AutogeneratedRoute()
        {
            DateTime date = (from Route in db.Routes orderby Route.date descending select Route.date).FirstOrDefault();
            var busId = (from busSchedule in db.BusSchedules select busSchedule.bId).Distinct();
            if (date == null)
            {
                while (date <= DateTime.Now.AddDays(60))
                {
                   
                    foreach (var item in busId)
                    {
                      
                        var BlockTimeId = (from bs in db.BusSchedules where bs.bId == item select bs);
                        foreach (var a in BlockTimeId)
                        {

                            double p = a.BlockTime.btPrice * a.Bus.BusDetail.bdPrice;
                            //var route = db.Set<Route>();
                            //db.Routes.Add(new Route { bId = item, btId = a.btId, date = date, rPrice = p });
                            //db.SaveChanges();
                            var dao = new AdminController();
                            dao.AddRoute(item, a.btId, p, date);
                            ModelState.AddModelError("", "Autogenerated routes successful");
                        }

                    }
                   date = date.AddDays(1);
                }
               
            }
            else
            {
                date = DateTime.Now;
                while (date <= DateTime.Now.AddDays(60))
                {
                    
                    foreach (var item in busId)
                    {
                       
                        var BlockTimeId = (from bs in db.BusSchedules where bs.bId == item select bs);
                        foreach (var a in BlockTimeId)
                        {

                            double p = a.BlockTime.btPrice * a.Bus.BusDetail.bdPrice;
                            //var route = db.Set<Route>();
                            //db.Routes.Add(new Route { bId = item, btId = a.btId, date = date, rPrice = p });
                            //db.SaveChanges();
                            var dao = new AdminController();
                            dao.AddRoute(item, a.btId, p, date);
                            ModelState.AddModelError("", "Autogenerated routes successful");
                        }
                    }
                    date = date.AddDays(1);
                }
            }


            return Content("<script>alert('It take a minutes!');</script>");
        }
        public ActionResult EditRoute()
        {
            return View();
        }

        #endregion Route
    }
}