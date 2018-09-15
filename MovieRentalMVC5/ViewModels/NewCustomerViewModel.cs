using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRentalMVC5.Models;

namespace MovieRentalMVC5.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

    }
}