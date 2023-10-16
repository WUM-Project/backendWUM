using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace Catalog.Domain.Entities
{

    public partial class ProductToAttribute
    {
        public int AttributeId { get; set; }
        public int Value { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
        public Attribute Attribute { get; set; }

       


    }
}