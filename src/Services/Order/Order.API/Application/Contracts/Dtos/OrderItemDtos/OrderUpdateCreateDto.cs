using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Order.Domain.Entities;
using System.ComponentModel.DataAnnotations;
namespace Order.Api.Application.Contracts.OrderItemDtos
{
    public class OrderUpdateCreateDto
    {
       public int TotalPrice { get; set; }
        public string UserId { get; set; }
        public int AddressId { get; set; }
        public int Status {get;set;}
         public string  Products { get; set; }

        //[Required(ErrorMessage = "Description is required")]
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "Comment can't be longer than 1000 characters and less then 5")]
        public string Comment { get; set; }



        [Range(1, 10, ErrorMessage = "In range from 1 to 10 minutes")]
        public int DeliveryType { get; set; }

        [Range(1, 10, ErrorMessage = "In range from 1 to 10 minutes")]
        public int PayType { get; set; }
           public List<Products> ProductsJson {get;set;}
    }
}
