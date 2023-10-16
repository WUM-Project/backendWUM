using System;

namespace Catalog.API.Application.Contracts.Dtos.CategoryDtos
{
    public class CategoryReadDto
    {
        public int Id { get; set; }
        
        public int ParentId { get; set; }
        public string Lang { get; set; }
        public string Title { get; set; }
        public int? ImageId { get; set; }
    

    }

}