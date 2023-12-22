using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Order.Domain.Entities
{
    public class Orders
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int AddressId { get; set; }
          public Address Address{get;set;}
        public int Status { get; set; }
      
        public string  Products { get; set; }


        public int TotalPrice { get; set; }
        public int DeliveryType { get; set; }
        public int PayType { get; set; }
          public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        
    }
}
