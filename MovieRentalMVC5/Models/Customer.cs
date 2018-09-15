using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;    //Required for Data notation

namespace MovieRentalMVC5.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]  // not Nullable - overide data notation
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubsribedToNewsLetter { get; set; }

        [Display(Name ="Date of Birth")]
        public DateTime? Birthdate{ get; set; }

        //Navigation , ref to Membership Table
        public MembershipType MembershipType { get; set; }

        //FK to membership table, <Table_Name>Id -> Convention, treat as FK
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }
    }
}