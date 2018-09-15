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

        //NEw Customer
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
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