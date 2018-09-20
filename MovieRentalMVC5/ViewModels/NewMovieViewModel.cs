using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRentalMVC5.Models;

namespace MovieRentalMVC5.ViewModels
{
    public class NewMovieViewModel
    {
        public Movie Movie{ get; set; }
        public IEnumerable<Genre> Genres { get; set; }

    }
}