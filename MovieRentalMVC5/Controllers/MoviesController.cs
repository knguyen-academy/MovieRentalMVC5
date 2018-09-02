using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalMVC5.Models;


namespace MovieRentalMVC5.Controllers
{
    public class MoviesController : Controller
    {

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };    // need MovieRentalMVC5.Models lib
            return View(movie);
        }

        // EXAMPLE of Parameter using Content Action
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        // EXAMPLE of passing parameter
        // Movie?pageIndex=2&sortBy=TestName
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
    }
}