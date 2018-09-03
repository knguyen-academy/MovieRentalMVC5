using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalMVC5.Models;
using MovieRentalMVC5.ViewModels;

namespace MovieRentalMVC5.Controllers
{
    public class MoviesController : Controller
    {


        public ActionResult Index()
        {
            var movies = GetMovies();
            return View(movies);

        }


        //Get List of movie
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {Id=1, Name="Shrek" },
                new Movie {Id=2, Name="Ironman"}
            };
        }


        // VIEW MODEL EXAMPLE
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };    // need MovieRentalMVC5.Models lib

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel() // need  MovieRentalMVC5.ViewModels lib
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        // EXAMPLE of Parameter using Content Action
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //// EXAMPLE of passing parameter to url
        //// Movie?pageIndex=2&sortBy=TestName
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";
        //    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}

        // EXAMPLE of Custom Route: movies/released/{year}/{month}
        // change: add custom route using using Attribute 
        // by add routes.MapMvcAttributeRoutes() in routeconfig.cs
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content(year + "/" + month);
        }
    }
}