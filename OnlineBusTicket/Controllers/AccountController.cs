using OnlineBusTicket.Models;
using OnlineBusTicket.Models.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBusTicket.Controllers
{
    public class AccountController : Controller
    {
        private SRCTravelAgenciesEntities db = new SRCTravelAgenciesEntities();
        Models.View.AccountView accView;

        // GET: Account
        public ActionResult Index()
        {
            var acc = new AccountController();
            var accList = acc.AccountList();
            return View(accList);
        }

        public IEnumerable<AccountView> AccountList()
        {
            List<AccountView> accountViews = new List<AccountView>();
            var result = (from a in db.Accounts
                          select new { a }
                          );

            foreach (var item in result)
            {
                accView = new AccountView();
                accView.account = item.a;
                accountViews.Add(accView);
            }

            return accountViews;

        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account acc)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var isExist = db.Accounts.SingleOrDefault(a => a.aId.Equals(acc.aId));
                    try
                    {
                        if (isExist == null)
                        {
                            db.Accounts.Add(acc);
                            db.SaveChanges();
                            return RedirectToAction("Index", "Account");
                        }
                        else
                        {
                            ModelState.AddModelError("", "This account is already existed");
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }


                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to add account.");
            }
            return View(acc);
        }

        public ActionResult Edit(int id)
        {
            Account result = db.Accounts.SingleOrDefault(a => a.aId.Equals(id));
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Account acc)
        {
            try
            {
                Account result = db.Accounts.SingleOrDefault(a => a.aId.Equals(acc.aId));
                if (ModelState.IsValid)
                {

                    result.aUsername = acc.aUsername;
                    result.aPassword = acc.aPassword;
                    result.aName = acc.aName;
                    result.aBirthday = acc.aBirthday;
                    result.aEmail = acc.aEmail;
                    result.aPhone = acc.aPhone;
                    db.Entry(result).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Please check if all fields are in correct formats.");
                }

            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    Account acc = db.Accounts.SingleOrDefault(a => a.aId.Equals(id));
                    try
                    {
                        if (acc != null)
                        {
                            db.Accounts.Remove(acc);
                            db.SaveChanges();
                            return RedirectToAction("Index", "Account");
                        }
                        else
                        {
                            ModelState.AddModelError("", "This account does not exist");
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
            return RedirectToAction("Index", "Account");
        }
    }
}