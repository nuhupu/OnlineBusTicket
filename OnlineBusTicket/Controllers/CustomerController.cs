using OnlineBusTicket.Models;
using OnlineBusTicket.Models.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBusTicket.Controllers
{
    public class CustomerController : Controller
    {
        private SRCTravelAgenciesEntities db = new SRCTravelAgenciesEntities();
        Models.View.CustomerView cusView;

        // GET: Customer
        public ActionResult Index()
        {
            var acc = new CustomerController();
            var cusList = acc.CustomerList();
            return View(cusList);
        }

        public IEnumerable<CustomerView> CustomerList()
        {
            List<CustomerView> customerViews = new List<CustomerView>();
            var result = (from a in db.Customers
                          select new { a }
                          );

            foreach (var item in result)
            {
                cusView = new CustomerView();
                cusView.customer = item.a;
                customerViews.Add(cusView);
            }

            return customerViews;

        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer cus)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var isExist = db.Customers.SingleOrDefault(a => a.cId.Equals(cus.cId));
                    try
                    {
                        if (isExist == null)
                        {
                            db.Customers.Add(cus);
                            db.SaveChanges();
                            return RedirectToAction("Index", "Customer");
                        }
                        else
                        {
                            ModelState.AddModelError("", "This customer is already existed");
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
                ModelState.AddModelError("", "Unable to create customer.");
            }
            return View(cus);
        }

        public ActionResult Edit(int id)
        {
            Customer result = db.Customers.SingleOrDefault(a => a.cId.Equals(id));
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer cus)
        {
            try
            {

                Customer result = db.Customers.SingleOrDefault(a => a.cId.Equals(cus.cId));
                if (ModelState.IsValid)
                {
                    result.cName = cus.cName;
                    result.cBirthday = cus.cBirthday;
                    result.cPhone = cus.cPhone;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Customer");
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

                    Customer cus = db.Customers.SingleOrDefault(a => a.cId.Equals(id));
                    try
                    {
                        if (cus != null)
                        {
                            db.Customers.Remove(cus);
                            db.SaveChanges();
                            return RedirectToAction("Index", "Customer");
                        }
                        else
                        {
                            ModelState.AddModelError("", "This customer does not exist");
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
            return RedirectToAction("Index", "Customer");
        }

    }
}