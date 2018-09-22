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
    public class MoviesController : Controller
    {
        // Initialize Movie context (from DB)
        private ApplicationDbContext _context;

        //Constructor
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //Destructor
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Index()
        {
            var movies = _context.Movies.Include(g => g.Genre).ToList();
            return View(movies);
        }

        //New Movie Form
        public ActionResult MovieForm()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                Genres = genres
            };

            return View(viewModel);
 
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            //If new movie
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now; //added date
                _context.Movies.Add(movie);
            }
            else
            {
                //get existing movie in DB
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                //Update moive
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            //Added/Edit 
            _context.SaveChanges(); //Commit changes to DB

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movies = _context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == id);
            if (movies == null)
                return HttpNotFound();
            else
            {
                var viewModel = new NewMovieViewModel
                {
                    Movie = movies,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
        }

        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == id);
            return View(movies);
        }

        ////PREVIOUS EXAMPLEs
        //public ActionResult Index()
        //{
        //    var movies = GetMovies();
        //    return View(movies);

        //}


        ////Get List of movie
        //private IEnumerable<Movie> GetMovies()
        //{
        //    return new List<Movie>
        //    {
        //        new Movie {Id=1, Name="Shrek" },
        //        new Movie {Id=2, Name="Ironman"}
        //    };
        //}


        //// VIEW MODEL EXAMPLE
        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shrek!" };    // need MovieRentalMVC5.Models lib

        //    var customers = new List<Customer>
        //    {
        //        new Customer {Name = "Customer 1"},
        //        new Customer {Name = "Customer 2"}
        //    };

        //    var viewModel = new RandomMovieViewModel() // need  MovieRentalMVC5.ViewModels lib
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };

        //    return View(viewModel);
        //}

        //// EXAMPLE of Parameter using Content Action
        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}

        ////// EXAMPLE of passing parameter to url
        ////// Movie?pageIndex=2&sortBy=TestName
        ////public ActionResult Index(int? pageIndex, string sortBy)
        ////{
        ////    if (!pageIndex.HasValue)
        ////        pageIndex = 1;
        ////    if (String.IsNullOrWhiteSpace(sortBy))
        ////        sortBy = "Name";
        ////    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        ////}

        //// EXAMPLE of Custom Route: movies/released/{year}/{month}
        //// change: add custom route using using Attribute 
        //// by add routes.MapMvcAttributeRoutes() in routeconfig.cs
        //[Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, byte month)
        //{
        //    return Content(year + "/" + month);
        //}
    }
}