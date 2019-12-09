using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidiling.Models;
using Vidiling.ViewModel;
namespace Vidiling.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [Authorize]
        public ActionResult Customer()
        {
            ViewBag.Message = "Your customers ifo.";

            // var list = _context.Customers.Include(c => c.MembershipType).ToList();

            return View();//(list);
        }
        public ActionResult ViewCustomer(int id)
        {

            var cust = _context.Customers.Include(c => c.MembershipType).Where(x => x.Id == id).SingleOrDefault();
            return View(cust);
        }
        public ActionResult CustomerForm()
        {
            var membershiptypes = _context.MembershipType.ToList();
            CustomerViewModel newcustomer = new CustomerViewModel {MembershipTypes=membershiptypes,Customer=new Customer() };
           

            return View(newcustomer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                CustomerViewModel cc = new CustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipType.ToList()
                };
                return View("CustomerForm", cc);
            }
           
                if (customer.Id == 0)
                {
                    _context.Customers.Add(customer);
                }
                else
                {
                    var custindb = _context.Customers.Single(c => c.Id == customer.Id);
                    custindb.Name = customer.Name;
                    custindb.Birthday = customer.Birthday;
                    custindb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                    custindb.MembershipTypeId = customer.MembershipTypeId;
                }
                _context.SaveChanges();
                return RedirectToAction("Customer", "Customer");
            
        }
        public ActionResult Edit( int id)
        {
            var customer = _context.Customers.Where(x => x.Id == id).SingleOrDefault();
            if (customer == null)
                return HttpNotFound();
            var customerviewmodel = new CustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipType.ToList()
            };
        
            return View("CustomerForm",customerviewmodel);
        }
    }
}