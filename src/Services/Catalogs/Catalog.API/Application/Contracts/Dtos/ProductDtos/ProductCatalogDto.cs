using System;
using Catalog.Domain.Entities;
namespace Catalog.API.Application.Contracts.Dtos.ProductDtos
{
    public class ProductCatalogDto
    {
       public int Id { get; set; }

        public int? OriginId { get; set; }
        public string Lang { get; set; }
        
        public int Status { get; set; }
       
      
     
        public int Price { get; set; } 
        public int DiscountedPrice { get; set; } 
       
        public string Name { get; set; } = null!;
  
   
       
        public int? Popular { get; set; }
        public int? ImageId { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

       

       public UploadedFiles UploadedFiles {get;set;}
            public IEnumerable<ProductToMark>  Marks  { get; set; }
            public IEnumerable<ProductToAttribute>  Attributes  { get; set; }
            public IEnumerable<ProductToCategory>  Categories  { get; set; }
            // = new List<ProductToCategory>();
    

    }
    

}