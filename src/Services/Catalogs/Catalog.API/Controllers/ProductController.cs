using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Catalog.API.Application.Pagginations;
using Catalog.API.Application.Services.Interfaces;
using System.Linq.Expressions;
using Catalog.API.Application.Contracts.Dtos.ProductDtos;
using Catalog.API.Application.Contracts.Dtos.AttributeDtos;
using Catalog.Domain.Entities;


namespace Catalog.API.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class ProductsController : ControllerBase
  {

    private readonly IServiceManager _serviceManager;
    private readonly IWebHostEnvironment environment;
    public ProductsController(IServiceManager serviceManager, IWebHostEnvironment environment)
    {
      this.environment = environment;
      _serviceManager = serviceManager;
    }


 
    [HttpGet]
    [Route("AttributeFilters")]
    public async Task<IActionResult> GetAllAttributes(
     CancellationToken cancellationToken = default)
    {

      Console.WriteLine("\n---> Getting All Attributes...");

      var result = await _serviceManager.ProductService.GetAllAttributesAsync(cancellationToken);
      string lang = "uk";
      Console.WriteLine(result);
      if (!String.IsNullOrEmpty(lang))
      {

        result = result?.Where(x => x.Lang?.Contains(lang.ToLower()) ?? false)?.ToList();
      }




      return Ok(result);
    }
    [HttpGet]
    [Route("GetAllBrands")]
    public async Task<IActionResult> GetAllBrands(
     CancellationToken cancellationToken = default)
    {

      Console.WriteLine("\n---> Getting All Brands...");

      var result = await _serviceManager.ProductService.GetAllBrandsAsync(cancellationToken);
      string lang = "uk";
      Console.WriteLine(result);
      if (!String.IsNullOrEmpty(lang))
      {

        result = result?.Where(x => x.Lang?.Contains(lang.ToLower()) ?? false)?.ToList();
      }




      return Ok(result);
    }

    [HttpGet]
    [Route("FindAllProducts")]
    public async Task<IActionResult> GetProducts(int page, string filter, string? attributeIds,
string? attributeValues, int categoryId, decimal? minPrice,  // Nullable decimal for the minimum price
decimal? maxPrice,  // Nullable decimal for the maximum price
 int middleVal = 10,
int cntBetween = 5, int limit = 15, string sortBy = "newest",
int? brandId = null,
CancellationToken cancellationToken = default)
    {
      Console.WriteLine("\n---> Getting All Products...");
      // Збір пар ідентифікаторів та значень атрибутів у масив
      List<AttributeProductDto> attributes = new List<AttributeProductDto>();
      List<int> parsedAttributeIds = attributeIds?.Split(',').Select(int.Parse).ToList() ?? new List<int>();
      List<string> parsedAttributeValues = attributeValues?.Split(',').ToList() ?? new List<string>();
      if (parsedAttributeIds.Count > 0 && parsedAttributeValues.Count > 0)
      {
        attributes = parsedAttributeIds
            .Zip(parsedAttributeValues, (id, value) => new AttributeProductDto { AttributeId = id, Value = value })
            .ToList();
      }
      Console.WriteLine(attributes);
      // Оригінальний вираз predicate, який фільтрує за вказаними умовами
      Expression<Func<Product, bool>> originalPredicate = p =>
          (String.IsNullOrEmpty(filter) || (p.Name.ToLower() + " " + p.Description.ToLower()).Contains(filter.ToLower()))
          && (categoryId == 0 || p.Categories.Any(c => c.CategoryId == categoryId))
          && (!minPrice.HasValue || p.Price >= minPrice.Value)
          && (!maxPrice.HasValue || p.Price <= maxPrice.Value)
            && (!brandId.HasValue || p.BrandId == brandId.Value);
      string lang = "uk";



      var products = await _serviceManager.ProductService.FindAllProduct(originalPredicate, cancellationToken);
      if (!String.IsNullOrEmpty(lang))
      {

        products = products?.Where(x => x.Lang?.Contains(lang.ToLower()) ?? false)?.ToList();
      }
      if (attributes != null && attributes.Count > 0)
      {

        //       products =   products.Where(p =>
        //     attributes.Any(attr => p.Attributes.Any(a => a.AttributeId == attr.AttributeId && a.Value == attr.Value))
        // );
        products = products.Where(p =>
      attributes.All(attr => p.Attributes.Any(a => a.AttributeId == attr.AttributeId && a.Value == attr.Value))
  ).Select(p => p);
        // Застосування додаткових умов фільтрації за категорією, можливо, іншими фільтрами
      }
      if (middleVal <= cntBetween)
      {
        return BadRequest(new { Error = "MiddleVal must be more than cntBetween" });
      }


      //    Додавання сортування
      switch (sortBy.ToLower())
      {
        //фільтр по зростанню ціни 
        case "price_asc":
          products = products.OrderBy(p => p.Price);
          break;
        //фільтр по спаданню ціни 
        case "price_desc":
          products = products.OrderByDescending(p => p.Price);
          break;
        case "newest":
          products = products.OrderByDescending(p => p.CreatedAt); // Assuming there is a CreatedAt property
          break;
        default:
          // Handle other cases or provide a default sorting
          break;
      }

      // Використання пагінації для повернення результатів
      var paginatedProducts = Paggination<ProductCatalogDto>.GetData(currentPage: page, limit: limit, itemsData: products,
          middleVal: middleVal, cntBetween: cntBetween);
      // Мапування до ProductReadDto
      // var productDtos = _mapper.Map<IEnumerable<ProductReadDto>>(paginatedProducts);

      return Ok(paginatedProducts);
    }
    [HttpPost]
    [Route("FindAllProducts")]
    // string? attributeIds,string? attributeValues,
    public async Task<IActionResult> FilterProducts(int page, string filter,
    [FromBody] List<AttributeProductValDto>? attributes,
 int categoryId, decimal? minPrice,  // Nullable decimal for the minimum price
decimal? maxPrice,  // Nullable decimal for the maximum price
 int middleVal = 10,
int cntBetween = 5, int limit = 15, string sortBy = "newest",
int? brandId = null,
CancellationToken cancellationToken = default)
    {
      Console.WriteLine("\n---> Getting All Products...");

      // Оригінальний вираз predicate, який фільтрує за вказаними умовами
      Expression<Func<Product, bool>> originalPredicate = p =>
          (String.IsNullOrEmpty(filter) || (p.Name.ToLower() + " " + p.Description.ToLower()).Contains(filter.ToLower()))
          && (categoryId == 0 || p.Categories.Any(c => c.CategoryId == categoryId))
          && (!minPrice.HasValue || p.Price >= minPrice.Value)
          && (!maxPrice.HasValue || p.Price <= maxPrice.Value)
            && (!brandId.HasValue || p.BrandId == brandId.Value);
      string lang = "uk";



      var products = await _serviceManager.ProductService.FindAllProduct(originalPredicate, cancellationToken);
      if (!String.IsNullOrEmpty(lang))
      {

        products = products?.Where(x => x.Lang?.Contains(lang.ToLower()) ?? false)?.ToList();
      }
      if (attributes != null && attributes.Count > 0)
      {
        products = products.Where(p =>
      attributes.All(attr => p.Attributes.Any(a => a.AttributeId == attr.AttributeId && a.Value == attr.Value))
  ).Select(p => p);
        // Застосування додаткових умов фільтрації за категорією, можливо, іншими фільтрами
      }
      if (middleVal <= cntBetween)
      {
        return BadRequest(new { Error = "MiddleVal must be more than cntBetween" });
      }


      //    Додавання сортування
      switch (sortBy.ToLower())
      {
        //фільтр по зростанню ціни 
        case "price_asc":
          products = products.OrderBy(p => p.Price);
          break;
        //фільтр по спаданню ціни 
        case "price_desc":
          products = products.OrderByDescending(p => p.Price);
          break;
        case "newest":
          products = products.OrderByDescending(p => p.CreatedAt); // Assuming there is a CreatedAt property
          break;
        default:
          // Handle other cases or provide a default sorting
          break;
      }

      // Використання пагінації для повернення результатів
      var paginatedProducts = Paggination<ProductCatalogDto>.GetData(currentPage: page, limit: limit, itemsData: products,
          middleVal: middleVal, cntBetween: cntBetween);
      // Мапування до ProductReadDto
      // var productDtos = _mapper.Map<IEnumerable<ProductReadDto>>(paginatedProducts);

      return Ok(paginatedProducts);
    }


    [HttpGet("{id}", Name = "GetProductById")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> GetUserById(int id, CancellationToken cancellationToken = default)
    {
      Console.WriteLine($"\n---> Getting product by Id: {id}");
      var productDto = await _serviceManager.ProductService.GetByIdAsync(id, cancellationToken);

      return Ok(productDto);
    }


















  }
}