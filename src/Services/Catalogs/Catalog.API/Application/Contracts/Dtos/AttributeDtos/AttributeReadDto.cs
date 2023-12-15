using System;
using Catalog.Domain.Entities;
namespace Catalog.API.Application.Contracts.Dtos.AttributeDtos
{
    public class AttributeReadDto
    {
        public int Id { get; set; }
        
        public int OriginId { get; set; }
        public string Lang { get; set; }
        public string Title { get; set; }
       
    

    }

}