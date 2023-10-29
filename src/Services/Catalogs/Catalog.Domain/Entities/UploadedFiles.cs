using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  Catalog.Domain.Entities
{
    public partial class UploadedFiles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public string Description { get; set; }
        public string UploadedBy { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
         public string FilePath { get; set; }
    }
}