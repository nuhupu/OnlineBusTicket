using OnlineBusTicket.Models;
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
            var blockTimeList = 
                                from a in db.BlockTimes
                                //join b in db.Counters on a.StartPlace equals b.counId
                                //join c in db.Counters on a.Destination equals c.counId
                                select a;
                                //new
                                //{
                                //    sp = b.counName,
                                //    ds = c.counName,
                                //    st = a.StartTime,
                                //    p = a.btPrice
                                //});
            
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
                if(ModelState.IsValid)
                {

                    var isExist = db.BlockTimes.FirstOrDefault(a => a.StartTime.Equals(blockTime.StartTime)&& a.StartPlace.Equals(blockTime.StartPlace)&& a.Destination.Equals(blockTime.Destination));
                    if (isExist == null)
                    {
                        db.BlockTimes.Add(blockTime);
                        db.SaveChanges();
                        return RedirectToAction("BlockTime","Admin");
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
            ViewBag.StartPlace = new SelectList(db.BlockTimes, "btId", "startPlace");
            ViewBag.Destination = new SelectList(db.BlockTimes, "btId", "destination");
            ViewBag.BusNumber = new SelectList(db.Buses, "btId", "destination");
            var busSchedules = from a in db.BusSchedules                                
                                select a;
            
            return View();
         
        }

        public ActionResult AddBusSchedule()
        {
            return View();
        }
    }
}