using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            List<Customer> customers = _context.Customers.Include(c => c.MemberShipType).ToList();
            return View(customers);
        }

        public ActionResult New()
        {
            IEnumerable<MembershipType> membershipTypes = _context.MembershipTypes.ToList();

            CustomerFormViewModel customerFormViewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer()
            };
             
            return View("CustomerForm", customerFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);

                CustomerFormViewModel customerFormViewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", customerFormViewModel);                
            }

            if (customer.Id == 0)
            {   
                _context.Customers.Add(customer);
            }
            else
            {
                Customer customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");            
        }

        public ActionResult Edit(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            CustomerFormViewModel customerFormViewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", customerFormViewModel);
        }

        public ActionResult Details(int id)
        {
            Customer customer = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}