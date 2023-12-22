using System;


namespace Order.Domain.Entities
{
    public class Products
    {
        public int Id { get; set; }
        
        public string  Name { get; set; }

        public int Count{ get;set;}
        public int Price { get; set; }
        public int DiscountedPrice { get; set; }
        public string ImagePath { get; set; }
       
    }
}
