using System;
using Order.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Order.Api.Application.Contracts.OrderItemDtos
{
    public class OrderCreateDto
    {
        [Required(ErrorMessage = "TotalPrice is required")]
        // [StringLength(100, MinimumLength = 5, ErrorMessage = "Title can't be longer than 100 characters and less then 5")]
        public int TotalPrice { get; set; }
        public string UserId { get; set; }

        //[Required(ErrorMessage = "Description is required")]
        // [StringLength(1000, MinimumLength = 5, ErrorMessage = "Comment can't be longer than 1000 characters and less then 5")]
        public string Comment { get; set; }
      public List<Products> ProductsJson {get;set;}

         

        // [Range(1, 10, ErrorMessage = "In range from 1 to 10 minutes")]
        public int DeliveryType { get; set; }

        // [Range(1, 10, ErrorMessage = "In range from 1 to 10 minutes")]
        public int PayType { get; set; }

        // [StringLength(1000, MinimumLength = 5, ErrorMessage = "Street can't be longer than 1000 characters and less then 5")]
        public string Street { get; set; }
        // [StringLength(5, MinimumLength = 0, ErrorMessage = "Apartment can't be longer than 1000 characters and less then 5")]
        public string Apartment { get; set; }
        // [StringLength(5, MinimumLength = 0, ErrorMessage = "House can't be longer than 1000 characters and less then 5")]
        public string House { get; set; }
        // [StringLength(50, MinimumLength = 0, ErrorMessage = "District can't be longer than 1000 characters and less then 5")]
        public string District { get; set; }
        // [StringLength(50, MinimumLength = 5, ErrorMessage = "Street can't be longer than 1000 characters and less then 5")]
        public string City { get; set; }
        // [StringLength(1000, MinimumLength = 5, ErrorMessage = "Department can't be longer than 1000 characters and less then 5")]
        public string Department { get; set; }
        // [StringLength(1000, MinimumLength = 5, ErrorMessage = "FirstName can't be longer than 1000 characters and less then 5")]
        public string FirstName { get; set; }
        // [StringLength(1000, MinimumLength = 5, ErrorMessage = "LastName can't be longer than 1000 characters and less then 5")]
        public string LastName { get; set; }
        // [StringLength(1000, MinimumLength = 5, ErrorMessage = "FatherName can't be longer than 1000 characters and less then 5")]
        public string FatherName { get; set; }
        // [StringLength(1000, MinimumLength = 5, ErrorMessage = "Email can't be longer than 1000 characters and less then 5")]
        public string Email { get; set; }
        // [StringLength(1000, MinimumLength = 5, ErrorMessage = "Phone can't be longer than 1000 characters and less then 5")]
        public string Phone { get; set; }
        // [StringLength(1000, MinimumLength = 5, ErrorMessage = "SelfPickupPoint can't be longer than 1000 characters and less then 5")]
        public string SelfPickupPoint { get; set; }



    }
}