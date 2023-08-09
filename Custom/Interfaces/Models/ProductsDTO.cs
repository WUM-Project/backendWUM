using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{

    public partial class ProductsDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int CategoryId { get; set; }

        public float? Price { get; set; }

        public string? Code { get; set; }

        public int? ManufacturerId { get; set; }

       
    }
}
