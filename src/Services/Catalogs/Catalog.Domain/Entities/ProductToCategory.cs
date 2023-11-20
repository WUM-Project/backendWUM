using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Catalog.Domain.Entities
{

    public partial class ProductToCategory
    {
       
        // public int Id { get; set; }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }

       
        public Category Category { get; set; }
       


    }
}