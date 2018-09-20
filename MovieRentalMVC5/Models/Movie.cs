using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MovieRentalMVC5.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name="Numbers in stock")]
        public byte NumberInStock { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Display(Name="Genre")]
        public byte GenreId { get; set; }
               
    }
}