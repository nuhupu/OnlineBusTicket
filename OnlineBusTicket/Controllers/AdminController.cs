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

        public ActionResult BlockTime()
        {
            ViewBag.CounterId = new SelectList(db.Counters, "counId", "counName");
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

        public ActionResult BusSchedule()
        {
            return View();
        }

        public ActionResult AddBusSchedule()
        {
            return View();
        }
    }
}