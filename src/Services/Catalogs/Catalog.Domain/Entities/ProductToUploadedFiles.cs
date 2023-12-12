using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Catalog.Domain.Entities
{

   public partial class ProductToUploadedFiles
    {
        // [Key]
        // public int Id { get; set; }
         [Key]
        [Column(Order = 0)]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
          [Key]
        [Column(Order = 1)]
        [ForeignKey("UploadedFile")] 
        public int UploadId { get; set; }

        // [ForeignKey(nameof(ProductId))]
        // public Product Product { get; set; }

        [ForeignKey(nameof(UploadId))]
        public UploadedFiles UploadedFile { get; set; }
       


    }
}