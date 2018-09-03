using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRentalMVC5.Models;

namespace MovieRentalMVC5.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}