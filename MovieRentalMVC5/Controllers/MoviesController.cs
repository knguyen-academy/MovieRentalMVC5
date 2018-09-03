﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalMVC5.Models;


namespace MovieRentalMVC5.Controllers
{
    public class MoviesController : Controller
    {

        // EXAMPLE: Movies/Random
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

        // EXAMPLE of passing parameter to url
        // Movie?pageIndex=2&sortBy=TestName
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

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