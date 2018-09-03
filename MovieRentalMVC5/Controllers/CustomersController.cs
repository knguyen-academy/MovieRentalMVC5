using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalMVC5.Models;

namespace MovieRentalMVC5.Controllers
{
    public class CustomersController : Controller
    {
        // INDEX
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }



        //Customers/Detail/id
        //Explain:
        //Basically you get the list of customers, then you use the method SingleOrDefault to get a single value or a default value 
        //where you abreviate every object inside of the list, meaning c is the same as a customer 
        //then you compare the id of the c object with the id argument you received in your action.
        //SingleOrDefault => "Returns the only element of a sequence, or a default value if the sequence is empty; "
        public ActionResult Details(int id)
        {

            var customers = GetCustomers().SingleOrDefault(c => c.Id == id);
            if (customers == null)
                return HttpNotFound();

            return View(customers);
        }


        // GetCustomers Function
        // Return a list of customers
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
           {
                new Customer {Id=1, Name ="John Smith"},
                new Customer {Id=2, Name ="Mary Williams"}
           };

        }
    }
}