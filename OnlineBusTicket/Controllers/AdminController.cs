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
            //ViewBag.CounterId = from a in db.Counters
            //                    select a;
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
        //get list BusSchedule
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
                    Text = "From " + item.Counter1.counName + " to " + item.Counter.counName + " Price " + item.btPrice.ToString()
                });
            }
            return selectList;
        }

        public ActionResult AddBusSchedule()
        {
            var admin = new AdminController();
            var buses = GetAllBuses();
            var blockTimes = GetAllBlockTimes();
            admin.GetSelectListBuses(buses);
            admin.GetSelectListBlockTimes(blockTimes);
            ViewBag.Bus = admin.GetSelectListBuses(buses); ;
            ViewBag.BlockTime = admin.GetSelectListBlockTimes(blockTimes); ;
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

        public IEnumerable<RouteView> ListRoute(int id)
        {
            List<RouteView> routeViews = new List<RouteView>();
            var result = (from a in db.Routes
                          join b in db.BlockTimes on a.btId equals b.btId
                          join c in db.Buses on a.bId equals c.bId
                          join d in db.RouteDetails on a.rId equals d.rId
                          join e in db.Seats on d.sId equals e.sId
                          where a.rId == id
                          select new
                          {
                              a,
                              b,
                              c,
                              d,
                              e
                          });

            RouteView routeView;
            foreach (var tem in result)
            {
                routeView = new RouteView();
                routeView.route = tem.a;
                routeView.block = tem.b;
                routeView.bus = tem.c;
                routeView.routeDetail = tem.d;
                routeView.seat = tem.e;
                routeViews.Add(routeView);
            }

            return routeViews;

        }

        public ActionResult RouteDetails(int id)
        {

            ViewBag.CounterName = new SelectList(db.Counters, "counId", "counName");
            var dao = new AdminController();
            var routeViews = dao.ListRoute(id);
            return View(routeViews);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRoute(int b, int bt, double p, DateTime d)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var r = new Route { bId = b, btId = bt, rPrice = p, date = d };
                    db.Routes.Add(r);
                    db.SaveChanges();
                    


                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRouteDetails(int r, int s)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    db.RouteDetails.Add(new RouteDetail { rId = r, sId = s,avaibility = 1 });
                    db.SaveChanges();


                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }
        public ActionResult AutogeneratedRouteDetails()
        {
            var routeList = from route in db.Routes select route.rId;
            foreach (var routeId in routeList)
            {
                var numberOfSeat = (from a in db.Seats
                                    join b in db.Routes on a.bId equals b.bId
                                    where b.rId == routeId
                                    select a.sId);
                
                foreach (var item in numberOfSeat)
                {
                    var admin = new AdminController();
                    admin.AddRouteDetails(routeId, item);
                }

            }
            return View();
        }

        public ActionResult AutogeneratedRoute()
        {
            var lastR = (from Route in db.Routes orderby Route.date descending select Route).FirstOrDefault();
            var busId = (from busSchedule in db.BusSchedules select busSchedule.bId).Distinct();
            if (lastR == null)
            {

                var date = DateTime.Now;
                while (date.Date <= DateTime.Now.AddDays(10).Date)
                {

                    foreach (var item in busId)
                    {

                        var BlockTimeId = (from bs in db.BusSchedules where bs.bId == item select bs);
                        foreach (var a in BlockTimeId)
                        {

                            double p = a.BlockTime.btPrice * a.Bus.BusDetail.bdPrice;
                            var dao = new AdminController();
                            var isExist = db.Routes.FirstOrDefault(b => b.bId.Equals(item) && b.btId.Equals(a.btId) && b.rPrice.Equals(p) && b.date.Equals(date));
                            if (isExist == null)
                            {
                                dao.AddRoute(item, a.btId, p, date.Date);
                            }
                            else
                            {
                                continue;
                            }

                            ModelState.AddModelError("", "Autogenerated routes successful");
                        }
                    }
                    date = date.AddDays(1);
                }

            }
            else
            {
                var date = lastR.date;
                if (date.Date <= DateTime.Now.AddDays(60).Date)
                {
                    while (date.Date <= DateTime.Now.AddDays(10).Date)
                    {

                        foreach (var item in busId)
                        {

                            var BlockTimeId = (from bs in db.BusSchedules where bs.bId == item select bs);
                            foreach (var a in BlockTimeId)
                            {

                                double p = a.BlockTime.btPrice * a.Bus.BusDetail.bdPrice;
                                var dao = new AdminController();
                                var isExist = db.Routes.FirstOrDefault(b => b.bId.Equals(item) && b.btId.Equals(a.btId) && b.rPrice.Equals(p) && b.date.Equals(date));
                                if (isExist == null)
                                {
                                    dao.AddRoute(item, a.btId, p, date.Date);
                                }
                                else
                                {
                                    continue;
                                }

                                ModelState.AddModelError("", "Autogenerated routes successful");
                            }
                        }
                        date = date.AddDays(1);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Routes is added");
                }
            }
            AutogeneratedRouteDetails();

            return View();
        }
        public ActionResult EditRoute()
        {
            return View();
        }


        #endregion Route
    }
}