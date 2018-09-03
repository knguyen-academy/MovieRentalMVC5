using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalMVC5.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubsribedToNewsLetter { get; set; }

        //Navigation , ref to Membership Table
        public MembershipType MembershipType { get; set; }
        //FK to membership table, <Table_Name>Id -> Convention, treat as FK
        public int MembershipTypeId { get; set; }
    }
}