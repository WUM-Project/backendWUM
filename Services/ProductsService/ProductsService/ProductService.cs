using Interfaces;
using Interfaces.Models;
using Microsoft.EntityFrameworkCore;
using ProductsService.Models;

namespace ProductsService

{
    public class ProductService : IProductService

    {
        WumContext _context;

        public ProductService(WumContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<ProductsDTO>> GetAsync()
        {
            var result = new List<ProductsDTO>();
            var products = _context.Products;

            foreach (var product in products)
            {
                var productsDTO = new ProductsDTO();
                productsDTO.ManufacturerId = product.ManufacturerId;
                productsDTO.Name = product.Name;
                productsDTO.Description = product.Description;
                productsDTO.CategoryId = product.CategoryId;
                productsDTO.Code = product.Code;

                result.Add(productsDTO);
            }

            return Task.FromResult<IEnumerable<ProductsDTO>>(result);
        }
    }


    
}
