using OnlineBusTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBusTicket.Controllers
{
    public class LoginController : Controller
    {
        private SRCTravelAgenciesEntities db = new SRCTravelAgenciesEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Account account)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var isExist = db.Accounts.FirstOrDefault(a => a.aUsername.Equals(account.aUsername) || a.aEmail.Equals(account.aEmail) || a.aPhone.Equals(account.aPhone));
                    if (isExist == null)
                    {
                        using (var databaseContext = new SRCTravelAgenciesEntities())
                        {
                            Account re = new Account();

                            re.aName = account.aName;
                            re.aPassword = account.aPassword;
                            re.aUsername = account.aUsername;
                            re.aBirthday = account.aBirthday;
                            re.aEmail = account.aEmail;
                            re.aPhone = account.aPhone;

                            databaseContext.Accounts.Add(re);
                            databaseContext.SaveChanges();
                            return RedirectToAction("Index", "Login");
                        }
                        //db.Accounts.Add(account);
                        //db.SaveChanges();
                        //return RedirectToAction("Register", "Login");
                        ViewBag.Message = "Add account successfully";
                    }
                    else
                    {
                        ModelState.AddModelError("", "Account is existed");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(account);
        }
    }
}