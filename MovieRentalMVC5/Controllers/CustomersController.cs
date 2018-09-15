using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalMVC5.Models;
using MovieRentalMVC5.ViewModels;
using System.Data.Entity; //need for Eager loading

namespace MovieRentalMVC5.Controllers
{
    public class CustomersController : Controller
    {


        ///////////// QUERY DATA By DbContex //////////////
        private ApplicationDbContext _context;

        //Constructor
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //Dipose
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //New CustomerForm
        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }

        //Edit Customer
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);

        }

        //SAVE BUTTON ACTION
        // if new customer (customer.id =0) -> add to DB, if existed customer -> update 
        //Only be called after post
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            //If new Customer
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);   //Add to DB
            }

            //If existing customer
            else
            {
                //get existing customer in DB
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //Update customer
                //TryUpdateModel(customerInDb);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubsribedToNewsLetter = customer.IsSubsribedToNewsLetter;
            }
            _context.SaveChanges(); //Commit changes to DB

            return RedirectToAction("Index","Customers");
        }

        public ActionResult Index()
        {
            // get Customer Dbcontext, and Include Reference Membership table
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {

            var customers = _context.Customers.Include(m => m.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customers == null)
                return HttpNotFound();

            return View(customers);
        }

        //****** Previous Example ******/////
        ///////////// BEGIN QUERY DATA BY GetCustomer //////////
        //// INDEX
        //public ActionResult Index()
        //{
        //    var customers = GetCustomers();
        //    return View(customers);
        //}



        ////Customers/Detail/id
        ////Explain:
        ////Basically you get the list of customers, then you use the method SingleOrDefault to get a single value or a default value 
        ////where you abreviate every object inside of the list, meaning c is the same as a customer 
        ////then you compare the id of the c object with the id argument you received in your action.
        ////SingleOrDefault => "Returns the only element of a sequence, or a default value if the sequence is empty; "
        //public ActionResult Details(int id)
        //{

        //    var customers = GetCustomers().SingleOrDefault(c => c.Id == id);
        //    if (customers == null)
        //        return HttpNotFound();

        //    return View(customers);
        //}


        //// GetCustomers Function
        //// Return a list of customers
        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //   {
        //        new Customer {Id=1, Name ="John Smith"},
        //        new Customer {Id=2, Name ="Mary Williams"}
        //   };

        //}
        ///////////// END QUERY DATA BY GetCustomer //////////
    }
}