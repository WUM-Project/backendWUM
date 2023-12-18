using System;
using Catalog.Domain.Entities;
namespace Catalog.API.Application.Contracts.Dtos.BrandDtos
{
    public class BrandReadDto
    {
        public int Id { get; set; }
        public string Lang { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
       
    

    }

}