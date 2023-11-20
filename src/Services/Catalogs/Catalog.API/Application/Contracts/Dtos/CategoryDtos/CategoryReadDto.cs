using System;
using Catalog.Domain.Entities;
namespace Catalog.API.Application.Contracts.Dtos.CategoryDtos
{
    public class CategoryReadDto
    {
        public int Id { get; set; }
        
        public int ParentId { get; set; }
        public string Lang { get; set; }
        public string Title { get; set; }
        public int? ImageId { get; set; }
        public UploadedFiles UploadedFiles { get; set; }
       
        public int? IconId { get; set; }
        public UploadedFiles UploadedFileIcon { get; set; }
    

    }

}