using System;
using Order.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Order.Api.Application.Contracts.AddressItemDtos
{
    public class AddressCreateDto
    {
       

        [StringLength(1000, MinimumLength = 5, ErrorMessage = "Street can't be longer than 1000 characters and less then 5")]
        public string Street { get; set; }
        // [StringLength(5, MinimumLength = 0, ErrorMessage = "Apartment can't be longer than 1000 characters and less then 5")]
        public string Apartment { get; set; }
        [StringLength(5, MinimumLength = 0, ErrorMessage = "House can't be longer than 1000 characters and less then 5")]
        public string House { get; set; }
        [StringLength(50, MinimumLength = 0, ErrorMessage = "District can't be longer than 1000 characters and less then 5")]
        public string District { get; set; }
        // [StringLength(50, MinimumLength = 5, ErrorMessage = "Street can't be longer than 1000 characters and less then 5")]
        public string City { get; set; }
        // [StringLength(1000, MinimumLength = 5, ErrorMessage = "Department can't be longer than 1000 characters and less then 5")]
        public string Department { get; set; }
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "FirstName can't be longer than 1000 characters and less then 5")]
        public string FirstName { get; set; }
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "LastName can't be longer than 1000 characters and less then 5")]
        public string LastName { get; set; }
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "FatherName can't be longer than 1000 characters and less then 5")]
        public string FatherName { get; set; }
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "Email can't be longer than 1000 characters and less then 5")]
        public string Email { get; set; }
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "Phone can't be longer than 1000 characters and less then 5")]
        public string Phone { get; set; }
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "SelfPickupPoint can't be longer than 1000 characters and less then 5")]
        public string SelfPickupPoint { get; set; }



    }
}