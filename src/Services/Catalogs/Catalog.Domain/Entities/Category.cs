using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
namespace Catalog.Domain.Entities
{

    public  class Category
    {
        public int Id { get; set; }

        public int? OriginId { get; set; }
        public string Lang { get; set; }
        public int? ParentId { get; set; }

        public string Title { get; set; }

        public int Status { get; set; }
         
       
                
        public int? ImageId { get; set; }
      public UploadedFiles UploadedFiles;
       
        public int? IconId { get; set; }
        public UploadedFiles UploadedFileIcon;
        public int? Position { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public IList<ProductToCategory>  Products  { get; set; }

        
        // public IList<Category> Children {get;set;}
        // public virtual ICollection<Product> Product { get; set; }= new List<Product>();

    }
}