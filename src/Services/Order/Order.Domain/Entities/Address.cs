using System;
using System.Collections.Generic;

namespace Order.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
      
        public string  Street { get; set; }
        public string  Apartment { get; set; }
        public string  House { get; set; }
        public string  District { get; set; }
        public string  City { get; set; }
        public string  Department { get; set; }
        public string  FirstName { get; set; }
        public string  LastName { get; set; }
        public string  FatherName { get; set; }
        public string  Email { get; set; }
        public string  Phone { get; set; }
        public string  SelfPickupPoint { get; set; }
           public IList<Orders> Orders { get; } = new List<Orders>();

    }
}
