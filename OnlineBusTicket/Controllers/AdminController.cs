using OnlineBusTicket.Models;
using OnlineBusTicket.Models.View;
using System;
using System.Collections.Generic;
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

        public ActionResult Route()
        {
            return View();
        }

        public ActionResult EditRoute()
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
                busTimeView.id = tem.a.gbtId;
                busTimeView.block = tem.b;
                busTimeView.bus = tem.c;
                busScheduleViews.Add(busTimeView);
            }

            return busScheduleViews;

        }
        public ActionResult AddBusSchedule()
        {
            ViewBag.Bus = new SelectList(db.Buses, "bId", "bNumber");
            ViewBag.BlockTime = new SelectList(db.BlockTimes, "btId", "btId");
            ViewBag.BusSchedule = new SelectList(db.BusSchedules, "btId", "btId");
            return View();
        }

        //public IEnumerable<UnselectedBlockTimeView> unselectedBlocks()
        //{
        //    List<UnselectedBlockTimeView> unselectedBlocks = new List<UnselectedBlockTimeView>();
        //    var result = (from bt in db.BlockTimes
        //                  where bt.btId != (from bs in db.BusSchedules where bs.bId == 2 select bs.bId)
        //                  select new
        //                  {
        //                      bt,bs

        //                  });
        //    var isExist = db.BlockTimes.Where(a=>a.btId.Equals)

        //    EventView dbm;
        //    foreach (var tem in result)
        //    {
        //        dbm = new EventView();
        //        dbm.eventPost = tem.ev;
        //        dbm.eventImg = tem.img;
        //        EventList.Add(dbm);
        //    }

        //    return EventList;
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBusSchedule(BusSchedule busSchedule)
        {
            ViewBag.Bus = from a in db.Buses
                          select a;
            ViewBag.BlockTime = from b in db.BlockTimes
                                select b;
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
                            return RedirectToAction("BusSchedule", "Admin");
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
    }
}